﻿using HotUI.Internal.Reload;
using NUnit.Framework;
using System;
using HotUI.Samples;
using System.IO;
using System.Threading.Tasks;

namespace HotUI.Tests {
	[TestFixture ()]
	public class ReloadTests {
		IEvaluator eval;

		[Test ()]
		public async Task CanLoadCodeFromFile ()
		{
			//Reset the evaluator;
			eval = new Evaluator ();
			var request = new EvalRequestMessage {
				Code = File.ReadAllText ("TestView.txt"),
				FileName = "BasicTestView.cs",
				Classes = new System.Collections.Generic.List<(string NameSpace, string ClassName)> {
					("HotUI.Samples","BasicTestView")
				},
			};
			var result = new EvalResult ();
			var s = await eval.EvaluateCode (request, result);
			Assert.IsTrue (s);
		}

		[Test ()]
		public async Task CanReplaceAnExistingView ()
		{
			eval = new Evaluator ();
			var view = new BasicTestView ();
			Assert.IsNotNull (view);

			var request = new EvalRequestMessage {
				Code = File.ReadAllText ("TestView.txt"),
				FileName = "BasicTestView.cs",
				Classes = new System.Collections.Generic.List<(string NameSpace, string ClassName)> {
					("HotUI.Samples","BasicTestView")
				},
			};
			var result = new EvalResult ();
			var s = await eval.EvaluateCode (request, result);
			foreach (var r in result.FoundClasses)
				HotReloadHelper.RegisterReplacedView (r.ClassName, r.Type);

			var newView = view.GetView ();
			var newViewtype = newView?.GetType ();
			Assert.AreSame (newViewtype, typeof (Text));
		}
	}
}
