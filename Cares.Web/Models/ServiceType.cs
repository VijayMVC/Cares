
namespace Cares.Web.Models
{
    /// <summary>
    /// Service Type Web model
    /// </summary>
    public class ServiceType
    {
        /// <summary>
        ///Service Type Id
        /// </summary>
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Service Type Description
        /// </summary>
        public string ServiceTypeDescription { get; set; }
    }
}