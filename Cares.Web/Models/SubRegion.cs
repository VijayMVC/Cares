namespace Cares.Web.Models
{
    /// <summary>
    /// Sub Region Model
    /// </summary>
    public class SubRegion
    {
        #region Persisted Properties
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public int SubRegionId { get; set; }
        /// <summary>
        /// Sub Region Code
        /// </summary>
        public string SubRegionCode { get; set; }
        /// <summary>
        /// Sub Region Name
        /// </summary>
        public string SubRegionName { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public int RegionId { get; set; }
        #endregion
    }
}