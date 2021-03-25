﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.MSBuild;
using Mono.Unix;

namespace Reloadify.CommandLine
{
	public class IDE
	{
		static IDE()
		{
			VerifyTargets();
		}
		//MSBuildWorkspace currentWorkSpace;
		public static IDE Shared { get; set; } = new IDE();
		Project currentProject;
		string csprojPath;
		FileWatcher fileWatcher;
		string projectRoot;
		public async Task LoadProject(string projectRoot, string csprojPath, string configuration, string platform)
		{
			this.projectRoot = projectRoot;
			if (!File.Exists(csprojPath))
			{
				var combined = Path.Combine(projectRoot, csprojPath);
				if (File.Exists(combined))
					csprojPath = combined;
			}
			this.csprojPath = csprojPath;
			try
			{
				var currentWorkSpace = MSBuildWorkspace.Create(new Dictionary<string,string>() {
					["Configuration"] = configuration,
					["Platform"] = platform,
				});
				currentWorkSpace.WorkspaceFailed += CurrentWorkSpace_WorkspaceFailed;
				//var sln = await currentWorkSpace.OpenSolutionAsync(slnPath);
				//var project = sln.Projects.FirstOrDefault(x => x.FilePath.Contains(csp rojPath)) ?? await currentWorkSpace.OpenProjectAsync(csprojPath);
				Console.WriteLine($"Opening :{csprojPath}");
				var project = await currentWorkSpace.OpenProjectAsync(csprojPath);
				var sln = currentWorkSpace.CurrentSolution;
				Console.WriteLine($"Compiling :{csprojPath}");
				var compilation = await project.GetCompilationAsync();
				var errors = compilation.GetDiagnostics().Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error).ToList();
				Console.WriteLine($"Compiling Complete : Error Count: {errors?.Count() ?? 0}");
				foreach (var e in errors)
					Console.WriteLine($"\t: {e.GetMessage()}");
				currentProject = project;
				IDEManager.Shared.CurrentProjectPath = csprojPath;
				IDEManager.Shared.Solution = sln;
				//var sln = project.Solution;
				//var graph = sln.GetProjectDependencyGraph();
				//Msbuild failed when processing the file '/Users/clancey/Projects/Comet/src/Comet/Comet.csproj' with message: The SDK 'Microsoft.NET.Sdk' specified could not be found.  / Users / clancey / Projects / Comet / src / Comet / Comet.csproj                    IDEManager.Shared.Solution = sln;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
		bool isDebugging;
		public async Task StartHotReload()
		{
			if (isDebugging)
				return;
			isDebugging = true;
			IDEManager.Shared.CurrentProjectPath = csprojPath;
			fileWatcher = new FileWatcher(projectRoot);
			IDEManager.Shared.StartMonitoring();
		}

		public void Shutdown()
		{
			if (isDebugging)
				return;
			isDebugging = false;
			fileWatcher?.Dispose();
			IDEManager.Shared.StopMonitoring();
		}

		static void VerifyTargets()
		{

			bool isMacOS = System.Runtime.InteropServices.RuntimeInformation
											   .IsOSPlatform(OSPlatform.OSX);
			if (!isMacOS)
				return;


			//AppDomain currentDomain = AppDomain.CurrentDomain;
			//currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);

			var location = Path.GetDirectoryName(typeof(Program).Assembly.Location);
			var msBuildCurrentDir = Path.Combine(location, "Current");
			if (!Directory.Exists(msBuildCurrentDir))
			{
				const string realPath = "/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/xbuild/Current";
				CreateDirectorySymLink(realPath, msBuildCurrentDir);
			}


			var xamarinDir = Path.Combine(location, "Xamarin");
			if (!Directory.Exists(xamarinDir))
			{
				const string realPath = "/Library/Frameworks/Xamarin.iOS.framework/Versions/Current/lib/msbuild";
				CreateDirectorySymLink(realPath, xamarinDir);
			}
		}

		static void CreateDirectorySymLink(string source, string link)
		{
			var existing = new UnixDirectoryInfo(link);
			if (existing.Exists)
				return;
			new UnixDirectoryInfo(source).CreateSymbolicLink(link);
		}

		private void CurrentWorkSpace_WorkspaceFailed(object sender, WorkspaceDiagnosticEventArgs e)
		{
			Console.WriteLine(e.Diagnostic);
		}
	}
}