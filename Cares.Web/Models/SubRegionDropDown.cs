namespace Cares.Web.Models
{
    /// <summary>
    /// Sub Region Dropdown Model
    /// </summary>
    public class SubRegionDropDown
    {
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short SubRegionId { get; set; }
        /// <summary>
        /// Sub Region Code and Name
        /// </summary>
        public string SubRegionCodeName { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
    }
}