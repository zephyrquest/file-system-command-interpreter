﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fsci.client.Resources.TranslatedText {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Text {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Text() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("fsci.client.Resources.TranslatedText.Text", typeof(Text).Assembly);
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
        ///   Looks up a localized string similar to change the current working directory.
        /// </summary>
        internal static string command_cd_description {
            get {
                return ResourceManager.GetString("command.cd.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to changed current working directory to: {0}.
        /// </summary>
        internal static string command_cd_success {
            get {
                return ResourceManager.GetString("command.cd.success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to cd &lt;path&gt;.
        /// </summary>
        internal static string command_cd_synopsis {
            get {
                return ResourceManager.GetString("command.cd.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to operation failed: could not change current working directory to {0}.
        /// </summary>
        internal static string command_cd_unsuccess {
            get {
                return ResourceManager.GetString("command.cd.unsuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to clear the output area.
        /// </summary>
        internal static string command_clear_description {
            get {
                return ResourceManager.GetString("command.clear.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to clear.
        /// </summary>
        internal static string command_clear_synopsis {
            get {
                return ResourceManager.GetString("command.clear.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list all available commands with their description and synopsis.
        /// </summary>
        internal static string command_help_description {
            get {
                return ResourceManager.GetString("command.help.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to help.
        /// </summary>
        internal static string command_help_synopsis {
            get {
                return ResourceManager.GetString("command.help.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list the content inside the current working directory.
        /// </summary>
        internal static string command_ls_description {
            get {
                return ResourceManager.GetString("command.ls.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ls.
        /// </summary>
        internal static string command_ls_synopsis {
            get {
                return ResourceManager.GetString("command.ls.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to create a new directory in the current working directory.
        /// </summary>
        internal static string command_mkdir_description {
            get {
                return ResourceManager.GetString("command.mkdir.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to new directory created: {0}.
        /// </summary>
        internal static string command_mkdir_success {
            get {
                return ResourceManager.GetString("command.mkdir.success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to mkdir &lt;dir name&gt;.
        /// </summary>
        internal static string command_mkdir_synopsis {
            get {
                return ResourceManager.GetString("command.mkdir.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to operation failed: could not create directory with name {0}.
        /// </summary>
        internal static string command_mkdir_unsuccess {
            get {
                return ResourceManager.GetString("command.mkdir.unsuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to move a directory and its content inside another directory.
        /// </summary>
        internal static string command_mv_description {
            get {
                return ResourceManager.GetString("command.mv.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to moved directory {0} to {1}.
        /// </summary>
        internal static string command_mv_success {
            get {
                return ResourceManager.GetString("command.mv.success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to mv &lt;origin&gt; &lt;destination&gt;.
        /// </summary>
        internal static string command_mv_synopsis {
            get {
                return ResourceManager.GetString("command.mv.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to operation failed: could not move directory {0} to {1}.
        /// </summary>
        internal static string command_mv_unsuccess {
            get {
                return ResourceManager.GetString("command.mv.unsuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: command not found.
        /// </summary>
        internal static string command_notfound {
            get {
                return ResourceManager.GetString("command.notfound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to print the path of the current working directory.
        /// </summary>
        internal static string command_pwd_description {
            get {
                return ResourceManager.GetString("command.pwd.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to current working dir: {0}.
        /// </summary>
        internal static string command_pwd_success {
            get {
                return ResourceManager.GetString("command.pwd.success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to pwd.
        /// </summary>
        internal static string command_pwd_synopsis {
            get {
                return ResourceManager.GetString("command.pwd.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to remove a directory and its content.
        /// </summary>
        internal static string command_rm_description {
            get {
                return ResourceManager.GetString("command.rm.description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to removed directory: {0}.
        /// </summary>
        internal static string command_rm_success {
            get {
                return ResourceManager.GetString("command.rm.success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to rm &lt;path&gt;.
        /// </summary>
        internal static string command_rm_synopsis {
            get {
                return ResourceManager.GetString("command.rm.synopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to operation failed: could not remove directory at path {0}.
        /// </summary>
        internal static string command_rm_unsuccess {
            get {
                return ResourceManager.GetString("command.rm.unsuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: syntax error (usage {1}).
        /// </summary>
        internal static string command_syntaxerror {
            get {
                return ResourceManager.GetString("command.syntaxerror", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command.
        /// </summary>
        internal static string ui_command {
            get {
                return ResourceManager.GetString("ui.command", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your command here.
        /// </summary>
        internal static string ui_enter_command {
            get {
                return ResourceManager.GetString("ui.enter_command", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Language.
        /// </summary>
        internal static string ui_language {
            get {
                return ResourceManager.GetString("ui.language", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File System Command Interpreter.
        /// </summary>
        internal static string ui_title {
            get {
                return ResourceManager.GetString("ui.title", resourceCulture);
            }
        }
    }
}
