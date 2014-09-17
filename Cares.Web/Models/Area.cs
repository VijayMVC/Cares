
namespace Cares.Web.Models
{
    /// <summary>
    /// Area web model
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Area ID
        /// </summary>
        public short AreaId { get; set; }

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
        public short CityId { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string CityName { get; set; }
    }
}