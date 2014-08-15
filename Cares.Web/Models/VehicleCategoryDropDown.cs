namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Category Web Model
    /// </summary>
    public class VehicleCategoryDropDown
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
      

        /// <summary>
        /// Vehicle Category Code Name
        /// </summary>
        public string VehicleCategoryCodeName
        {
            get
            {
                return string.Format("{0}-{1}", VehicleCategoryCode, VehicleCategoryName);
            }
        }
        #endregion
    }
}