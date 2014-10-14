using System;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Ra Queue Search Request
    /// </summary>
    public class RaQueueSearchRequest : GetPagedListRequest
    {

        /// <summary>
        ///RA Number
        /// </summary>
        public long? RaNumber { get; set; }

        /// <summary>
        /// Ra Status Id
        /// </summary>
        public long? RaStatusId { get; set; }

        /// <summary>
        /// Open Location Id
        /// </summary>
        public long? OpenLocationId { get; set; }

        /// <summary>
        /// Close Location Id
        /// </summary>
        public long? CloseLocationId { get; set; }

        /// <summary>
        /// Payment Term Id
        /// </summary>
        public long? PaymentTermId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Ra Queue By Order
        /// </summary>
        public RaQueueByColumn RaQueueOrderBy
        {
            get
            {
                return (RaQueueByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
