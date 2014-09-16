
namespace Cares.Web.Models
{
    /// <summary>
    /// Country web model
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Country Description
        /// </summary>
        public string CountryDescription { get; set; }
    }
}