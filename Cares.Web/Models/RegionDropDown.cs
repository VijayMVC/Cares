namespace Cares.Web.Models
{
    /// <summary>
    /// Region Dropdown Model
    /// </summary>
    public class RegionDropDown
    {
        #region Persisted Properties
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
        /// <summary>
        /// Region Code and Name
        /// </summary>
        public string RegionCodeName { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Country Id
        /// </summary>
        public short? CountryId { get; set; }
        #endregion
    }
}