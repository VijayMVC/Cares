using System;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// NRT Queue Search Request
    /// </summary>
    public class NrtQueueSearchRequest : GetPagedListRequest
    {
        /// <summary>
        ///NRT Number
        /// </summary>
        public long? NrtNumber { get; set; }

        /// <summary>
        /// NRT Status Id
        /// </summary>
        public long? NrtStatusId { get; set; }

        /// <summary>
        /// NRT Type Id
        /// </summary>
        public long? NrtTypeId { get; set; }

        /// <summary>
        /// Open Location Id
        /// </summary>
        public long? OpenLocationId { get; set; }

        /// <summary>
        /// Close Location Id
        /// </summary>
        public long? CloseLocationId { get; set; }

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
        public NrtQueueByColumn NrtQueueOrderBy
        {
            get
            {
                return (NrtQueueByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
