namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Model Web Model
    /// </summary>
    public class VehicleModel
    {
        #region Public Properties
        /// <summary>
        /// Vehicle Mode ld
        /// </summary>
        public short VehicleModelId { get; set; }
        /// <summary>
        /// Vehicl eModel Code
        /// </summary>
        public string VehicleModelCode { get; set; }
        /// <summary>
        /// Vehicl eModel Name
        /// </summary>
        public string VehicleModelName { get; set; }
        /// <summary>
        /// Vehicle Model Description
        /// </summary>
        public string VehicleModelDescription { get; set; }

        /// <summary>
        /// Vehicle Model Code Name
        /// </summary>
        public string VehicleModelCodeName
        {
            get
            {
                return string.Format("{0}-{1}", VehicleModelCode, VehicleModelName);
            }
        }
        #endregion
    }
}