namespace Cares.Web.Models
{
    /// <summary>
    /// Region Model
    /// </summary>
    public class Region
    {
        #region Persisted Properties
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
        /// <summary>
        /// Region Code
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }
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