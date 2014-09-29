using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Seasonal Discount Base Domain Response
    /// </summary>
    public class SeasonalDiscountBaseResponse
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountBaseResponse()
        {
            Companies = new List<Company>();
            Departments = new List<Department>();
            Operations = new List<Operation>();
            TariffTypes = new List<TariffType>();
            OperationsWorkPlaces = new List<OperationsWorkPlace>();
            HireGroups = new List<HireGroup>();
            VehicleCategories = new List<VehicleCategory>();
            VehicleMakes = new List<VehicleMake>();
            VehicleModels = new List<VehicleModel>();
            BpRatingTypes = new List<BpRatingType>();
        }
        #endregion

        #region Public

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Tariff Types
        /// </summary>
        public IEnumerable<TariffType> TariffTypes { get; set; }

        /// <summary>
        /// Operations WorkPlaces
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// Hire Groups
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }

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
        /// Business Partner Rating Types
        /// </summary>
        public IEnumerable<BpRatingType> BpRatingTypes { get; set; }

        #endregion
    }
}
