using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Seacrh Request For NRT
    /// </summary>
// ReSharper disable once InconsistentNaming
    public class VehicleSeacrhRequestForNRT
    {
        /// <summary>
        /// Operation WorkPlace Id
        /// </summary>
        public long OperationWorkPlaceId { get; set; }

        /// <summary>
        /// Start Date Time
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date Time
        /// </summary>
        public DateTime EndDtTime { get; set; }
    }
}