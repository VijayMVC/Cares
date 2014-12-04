using System;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    public class BookingMainSearchRequest : GetPagedListRequest
    {
        /// <summary>
        ///BookingMain Number
        /// </summary>
        public long? BookingNumber { get; set; }

        /// <summary>
        /// BookingMain Status Id
        /// </summary>
        public long? StatusId { get; set; }

        /// <summary>
        /// Open Location Id
        /// </summary>
        public long? OpenLocationId { get; set; }

        /// <summary>
        /// Close Location Id
        /// </summary>
        public long? CloseLocationId { get; set; }
        
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
        /// BookingMain Queue By Order
        /// </summary>
        public BookingMainByColumn BookingMainOrderBy
        {
            get
            {
                return (BookingMainByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
