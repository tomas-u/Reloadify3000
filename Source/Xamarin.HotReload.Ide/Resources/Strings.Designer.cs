﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xamarin.HotReload.Ide.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Xamarin.HotReload.Ide.Resources.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hot Reload session ended..
        /// </summary>
        internal static string Agent_HotReload_State_Disabled_Text {
            get {
                return ResourceManager.GetString("Agent_HotReload_State_Disabled_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hot Reload session is connected and ready!.
        /// </summary>
        internal static string Agent_HotReload_State_Enabled_Text {
            get {
                return ResourceManager.GetString("Agent_HotReload_State_Enabled_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hot Reload session failed to connect, check the output logs for more information....
        /// </summary>
        internal static string Agent_HotReload_State_Failed_Text {
            get {
                return ResourceManager.GetString("Agent_HotReload_State_Failed_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hot Reload session is starting....
        /// </summary>
        internal static string Agent_HotReload_State_Starting_Text {
            get {
                return ResourceManager.GetString("Agent_HotReload_State_Starting_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xamarin Hot Reload enables developers to continually save changes to their XAML files and immediately view the results during a debugging session..
        /// </summary>
        internal static string Options_HotReload_Desc {
            get {
                return ResourceManager.GetString("Options_HotReload_Desc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Xamarin Hot Reload (Preview).
        /// </summary>
        internal static string Options_HotReload_Enable_Text {
            get {
                return ResourceManager.GetString("Options_HotReload_Enable_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xamarin Hot Reload is currently a Preview feature..
        /// </summary>
        internal static string Options_HotReload_Preview_Desc {
            get {
                return ResourceManager.GetString("Options_HotReload_Preview_Desc", resourceCulture);
            }
        }
    }
}