namespace Cares.Web.Models
{
    /// <summary>
    /// City Dropdown Web Api Model
    /// </summary>
    public class CityDropDown
    {
        /// <summary>
        /// City ID
        /// </summary>
        public short CityId { get; set; }
        /// <summary>
        /// City Custom ID
        /// </summary>
        public string CityCustomId { get; set; }

        /// <summary>
        /// City Code and Name
        /// </summary>
        public string CityCodeName { get; set; }

        /// <summary>
        /// Region ID
        /// </summary>
        public short? RegionId { get; set; }
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short? SubRegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
    }
}