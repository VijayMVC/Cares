﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cares.Implementation.Resources.Tariff {
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
    public class ChaufferCharge {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ChaufferCharge() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cares.Implementation.Resources.Tariff.ChaufferCharge", typeof(ChaufferCharge).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chauffer Charge for the selected tariff type already exist..
        /// </summary>
        public static string ChaufferChargeByTariffExist {
            get {
                return ResourceManager.GetString("ChaufferChargeByTariffExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Date for Chauffer Charge Rate must be a current or future date..
        /// </summary>
        public static string ChaufferChargeInvalidEffectiveDates {
            get {
                return ResourceManager.GetString("ChaufferChargeInvalidEffectiveDates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Date for Chauffer Charge Rate should be Greater or Equal to the Chauffer charge Policy Start Date..
        /// </summary>
        public static string ChaufferChargeInvalidRangeEffectiveDate {
            get {
                return ResourceManager.GetString("ChaufferChargeInvalidRangeEffectiveDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Date must be a current or future date..
        /// </summary>
        public static string InvalidStartDate {
            get {
                return ResourceManager.GetString("InvalidStartDate", resourceCulture);
            }
        }
    }
}