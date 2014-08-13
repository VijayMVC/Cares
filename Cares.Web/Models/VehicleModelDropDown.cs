namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Model Web Model
    /// </summary>
    public class VehicleModelDropDown
    {
        #region Public Properties
        /// <summary>
        /// Vehicle Mode ld
        /// </summary>
        public short VehicleModeld { get; set; }
        /// <summary>
        /// Vehicl eModel Code
        /// </summary>
        public string VehicleModelCodeName { get; set; }

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