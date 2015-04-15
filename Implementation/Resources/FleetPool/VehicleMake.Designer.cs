﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cares.Implementation.Resources.FleetPool {
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
    public class VehicleMake {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal VehicleMake() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cares.Implementation.Resources.FleetPool.VehicleMake", typeof(VehicleMake).Assembly);
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
        ///   Looks up a localized string similar to Vehicle Make with the same code already exists! Try different code!.
        /// </summary>
        public static string VehicleMakeCodeDuplicationError {
            get {
                return ResourceManager.GetString("VehicleMakeCodeDuplicationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Make is associated with Hire Group Detail.
        /// </summary>
        public static string VehicleMakeIsAssociatedWithHireGroupDetailError {
            get {
                return ResourceManager.GetString("VehicleMakeIsAssociatedWithHireGroupDetailError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Make is associated with Sessional Discount.
        /// </summary>
        public static string VehicleMakeIsAssociatedWithSessionalDiscountError {
            get {
                return ResourceManager.GetString("VehicleMakeIsAssociatedWithSessionalDiscountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Make is associated with Standard Discount.
        /// </summary>
        public static string VehicleMakeIsAssociatedWithStandardDiscountError {
            get {
                return ResourceManager.GetString("VehicleMakeIsAssociatedWithStandardDiscountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Make is associated with Vehicle!.
        /// </summary>
        public static string VehicleMakeIsAssociatedWithVehicleError {
            get {
                return ResourceManager.GetString("VehicleMakeIsAssociatedWithVehicleError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Make not found in database..
        /// </summary>
        public static string VehicleMakeNotFoundInDatabase {
            get {
                return ResourceManager.GetString("VehicleMakeNotFoundInDatabase", resourceCulture);
            }
        }
    }
}
