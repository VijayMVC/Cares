using System;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAdditionalChargeForNrtRequest
    {
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Vehicle id
        /// </summary>
        public long VehicleId { get; set; }
    }
}
