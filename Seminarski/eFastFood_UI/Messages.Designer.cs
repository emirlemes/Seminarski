﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eFastFood_UI {
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
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("eFastFood_UI.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Polje ne smije biti prazno..
        /// </summary>
        internal static string empty_string {
            get {
                return ResourceManager.GetString("empty_string", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Greška.
        /// </summary>
        internal static string error {
            get {
                return ResourceManager.GetString("error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Korisničko ime ili lozinka nisu ispravni..
        /// </summary>
        internal static string login_user_err {
            get {
                return ResourceManager.GetString("login_user_err", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cijena ne može biti negativna..
        /// </summary>
        internal static string negative_price {
            get {
                return ResourceManager.GetString("negative_price", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nije nađeno ili ne postoji..
        /// </summary>
        internal static string not_found {
            get {
                return ResourceManager.GetString("not_found", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Odaberite sliku većih dimenzija..
        /// </summary>
        internal static string picture_to_small {
            get {
                return ResourceManager.GetString("picture_to_small", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Polje je obavezno..
        /// </summary>
        internal static string required {
            get {
                return ResourceManager.GetString("required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Potrebno je više od 3 karaktera..
        /// </summary>
        internal static string string_length3 {
            get {
                return ResourceManager.GetString("string_length3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uspijeh.
        /// </summary>
        internal static string success {
            get {
                return ResourceManager.GetString("success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uspješno dodano..
        /// </summary>
        internal static string success_add {
            get {
                return ResourceManager.GetString("success_add", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Upozorenje.
        /// </summary>
        internal static string warning {
            get {
                return ResourceManager.GetString("warning", resourceCulture);
            }
        }
    }
}