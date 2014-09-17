
namespace Cares.Web.Models
{
    /// <summary>
    /// Region web model
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Region Code
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// Region Description
        /// </summary>
        public string RegionDescription { get; set; }
    }
}