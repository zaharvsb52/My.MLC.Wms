﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MLC.Wms.Api.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MLC.Wms.Api.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Ошибки в API APP &apos;Указать ГТД&apos;..
        /// </summary>
        internal static string ApiErrorChangeIwbGtd {
            get {
                return ResourceManager.GetString("ApiErrorChangeIwbGtd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибки в API APP &apos;Сменить владельца&apos;..
        /// </summary>
        internal static string ApiErrorChangeOwnerByOwb {
            get {
                return ResourceManager.GetString("ApiErrorChangeOwnerByOwb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Владелец товара соответствует владельцу, указанному в расходной накладной &apos;{0}&apos; (&apos;{1}&apos;), смена владельца не требуется..
        /// </summary>
        internal static string NotFoundProductsByOwner {
            get {
                return ResourceManager.GetString("NotFoundProductsByOwner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Обработка накладной &apos;{0}&apos; (&apos;{1}&apos;) в статусе &apos;{2}&apos; запрещена..
        /// </summary>
        internal static string OwbBadStatus {
            get {
                return ResourceManager.GetString("OwbBadStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Расходная накладная ид. &apos;{0}&apos; не найдена..
        /// </summary>
        internal static string OwbNotFound {
            get {
                return ResourceManager.GetString("OwbNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to У накладной &apos;{0}&apos; (&apos;{1}&apos;) не указан владелец..
        /// </summary>
        internal static string OwbOwnerUndefined {
            get {
                return ResourceManager.GetString("OwbOwnerUndefined", resourceCulture);
            }
        }
    }
}
