namespace Cares.Web.Models
{
    /// <summary>
    /// City Web Api Model
    /// </summary>
    public class City
    {
        #region Persisted Properties
        /// <summary>
        /// City ID
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// City Code
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// City Name
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// City Description
        /// </summary>
        public string CityDescription { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public int? SubRegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public int CountryId { get; set; }
        #endregion
    }
}