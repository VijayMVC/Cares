using System;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Get Chauffer Request
    /// </summary>
    public class GetRaChaufferRequest
    {
        /// <summary>
        /// Operations WorkPlace Id
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Designation Key
        /// </summary>
        public long DesignationKey { get; set; }

    }
}
