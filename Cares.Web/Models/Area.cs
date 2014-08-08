namespace Cares.Web.Models
{
    /// <summary>
    /// Area Web Api Model
    /// </summary>
    public class Area
    {
        #region Persisted Properties
        /// <summary>
        /// Area ID
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// Area Code
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// Area Name
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// Area Description
        /// </summary>
        public string AreaDescription { get; set; }
        /// <summary>
        /// City ID
        /// </summary>
        public int CityId { get; set; }
        #endregion
    }
}