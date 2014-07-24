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
        public IEnumerable<Company> Companies { get; set; }
        /// <summary>
        /// Hire Group 
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }
        /// <summary>
        /// Vehicle Categories
        /// </summary>
        public IEnumerable<VehicleCategory> VehicleCategories { get; set; }
        /// <summary>
        /// Vehicle Makes
        /// </summary>
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }
        /// <summary>
        /// Vehicle Models
        /// </summary>
        public IEnumerable<VehicleModel> VehicleModels { get; set; }
        /// <summary>
        /// Tariff types
        /// </summary>
        public IEnumerable<TarrifType> TariffTypes { get; set; }

        #endregion
    }
}