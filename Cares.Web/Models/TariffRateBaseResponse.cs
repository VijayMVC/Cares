using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Tariff Rate Base Web Response 
    /// </summary>    
    public class TariffRateBaseResponse
    {  
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }
        /// <summary>
        /// Hire Group 
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }
        /// <summary>
        /// Vehicle Categories
        /// </summary>
        public IEnumerable<VehicleCategoryDropDown> VehicleCategories { get; set; }
        /// <summary>
        /// Vehicle Makes
        /// </summary>
        public IEnumerable<VehicleMakeDropDown> VehicleMakes { get; set; }
        /// <summary>
        /// Vehicle Models
        /// </summary>
        public IEnumerable<VehicleModelDropDown> VehicleModels { get; set; }
        /// <summary>
        /// Tariff types
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        #endregion
    }
}