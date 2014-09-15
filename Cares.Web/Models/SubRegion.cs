
namespace Cares.Web.Models
{
    /// <summary>
    /// Sub Region web model
    /// </summary>
    public class SubRegion
    {
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short SubRegionId { get; set; }
        /// <summary>
        /// Sub Region Code
        /// </summary>
        public string SubRegionCode { get; set; }
        /// <summary>
        /// Sub Region Name
        /// </summary>
        public string SubRegionName { get; set; }
        /// <summary>
        /// Sub Region Description
        /// </summary>
        public string SubRegionDescription { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
    }
}