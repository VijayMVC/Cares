using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Category Web Model
    /// </summary>
    public class VehicleCategory
    {
        #region Public Properties
        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Category Code
        /// </summary>
        public string VehicleCategoryCode { get; set; }
        /// <summary>
        /// Vehicle Category Name
        /// </summary>
        public string VehicleCategoryName { get; set; }
        #endregion

    }
}