using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Seasonal Discount BaseWeb Response
    /// </summary>
    public class SeasonalDiscountBaseResponse
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountBaseResponse()
        {
            Companies = new List<CompanyDropDown>();
            Departments = new List<DepartmentDropDown>();
            Operations = new List<OperationDropDown>();
            TariffTypes = new List<TariffTypeDropDown>();
            OperationsWorkPlaces = new List<OperationsWorkPlaceDropDown>();
            HireGroups = new List<HireGroupDropDown>();
            VehicleCategories = new List<VehicleCategoryDropDown>();
            VehicleMakes = new List<VehicleMakeDropDown>();
            VehicleModels = new List<VehicleModelDropDown>();
            BpRatingTypes = new List<BpRatingTypeDropDown>();
        }
        #endregion

        #region Public

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departments { get; set; }

        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Tariff Types
        /// </summary>
        public IEnumerable<TariffTypeDropDown> TariffTypes { get; set; }

        /// <summary>
        /// Operations WorkPlaces
        /// </summary>
        public IEnumerable<OperationsWorkPlaceDropDown> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// Hire Groups
        /// </summary>
        public IEnumerable<HireGroupDropDown> HireGroups { get; set; }

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
        /// Business Partner Rating Types
        /// </summary>
        public IEnumerable<BpRatingTypeDropDown> BpRatingTypes { get; set; }

        #endregion
    }
}