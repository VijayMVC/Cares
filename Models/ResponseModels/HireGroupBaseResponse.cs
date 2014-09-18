using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Hire Group base Response
    /// </summary>
    public sealed class HireGroupBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupBaseResponse()
        {
            Companies = new List<Company>();
            ParentHireGroups = new List<HireGroup>();
            VehicleCategories = new List<VehicleCategory>();
            VehicleMakes = new List<VehicleMake>();
            VehicleModels = new List<VehicleModel>();
            HireGroups = new List<HireGroup>();
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
        public IEnumerable<HireGroup> ParentHireGroups { get; set; }
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
        /// Hire Groups i-e exlude parent hire groups
        /// </summary>
        public IEnumerable<HireGroup> HireGroups { get; set; }

        #endregion
    }
}
