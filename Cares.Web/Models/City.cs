

namespace Cares.Web.Models
{
    //web model
    public class City
    {
        /// <summary>
        /// City ID
        /// </summary>
        public short CityId { get; set; }

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
        public short? RegionId { get; set; }

        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short? SubRegionId { get; set; }

        /// <summary>
        /// Sub Region Name
        /// </summary>
        public string SubRegionName { get; set; }

        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }


        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }
    }
}