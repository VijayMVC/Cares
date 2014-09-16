using System;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Hire Group Domain Model Request
    /// </summary>
    public sealed class GetHireGroupRequest
    {
        /// <summary>
        /// Search Text
        /// </summary>
        public string SearchText { get; set; }

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
