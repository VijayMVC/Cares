using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Web Base Response
    /// </summary>
    public class HireGroupBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupBaseResponse()
        {
            Companies = new List<CompanyDropDown>();
            ParentHireGroups = new List<ParentHireGroup>();
            VehicleCategories = new List<VehicleCategoryDropDown>();
            VehicleMakes = new List<VehicleMakeDropDown>();
            VehicleModels = new List<VehicleModelDropDown>();
            HireGroups = new List<HireGroupDropDown>();
        }
        #endregion

        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }
        /// <summary>
        /// Hire Group 
        /// </summary>
        public IEnumerable<ParentHireGroup> ParentHireGroups { get; set; }
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
        /// Hire Groups i-e exlude parent hire groups
        /// </summary>
        public IEnumerable<HireGroupDropDown> HireGroups { get; set; }
        #endregion
    }
}