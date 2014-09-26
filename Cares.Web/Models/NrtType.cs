
namespace Cares.Web.Models
{
    /// <summary>
    /// Nrt Type  web model
    /// </summary>
    public class NrtType
    {      
        /// <summary>
        /// Nrt Type ID
        /// </summary>
        public long NrtTypeId { get; set; }

        /// <summary>
        /// Nrt Type Code
        /// </summary>
        public string NrtTypeCode { get; set; }

        /// <summary>
        /// Nrt Type Name
        /// </summary>
        public string NrtTypeName { get; set; }

        /// <summary>
        /// Nrt Type Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nrt Type Key
        /// </summary>
        public int? NrtTypeKey { get; set; }

        /// <summary>
        /// Standard Lifetime
        /// </summary>
        public double? StandardLifeTime { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short? VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Name
        /// </summary>
        public string VehicleStatusName { get; set; }
    }
}