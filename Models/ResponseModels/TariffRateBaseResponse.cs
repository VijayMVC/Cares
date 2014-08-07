using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Tariff Rate Base Domain Response 
    /// </summary>
    public sealed class TariffRateBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffRateBaseResponse()
        {
            Companies = new List<Company>();
            Departments = new List<Department>();
            Operations = new List<Operation>();
            HireGroups = new List<HireGroup>();
            VehicleCategories = new List<VehicleCategory>();
            VehicleMakes = new List<VehicleMake>();
            VehicleModels = new List<VehicleModel>();
            TariffTypes = new List<TarrifType>();
        }
        #endregion
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
