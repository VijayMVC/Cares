namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Make Web Model
    /// </summary>
    public class VehicleMakeDropDown
    {
        #region Public Properties
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }
        /// <summary>
        /// Vehicle Make Code
        /// </summary>
        public string VehicleMakeCodeName { get; set; }
       

        /// <summary>
        /// VehicleMake Code Name
        /// </summary>
        public string VehicleMakeCodeName
        {
            get
            {
                return string.Format("{0}-{1}", VehicleMakeCode, VehicleMakeName);
            }
        }
        #endregion
    }
}