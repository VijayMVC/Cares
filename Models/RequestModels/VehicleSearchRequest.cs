using System;
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Domain Model Request
    /// </summary>
    public sealed class VehicleSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }

        /// <summary>
        /// FleetPool ID
        /// </summary>
        public long? FleetPoolId { get; set; }

        /// <summary>
        /// Hire Group Search Text
        /// </summary>
        public string HireGroupString { get; set; }

        /// <summary>
        /// Operation ID
        /// </summary>
        public long? OperationId { get; set; }

        /// <summary>
        /// OperationsWorkPlace ID
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Start Dt
        /// </summary>
        public DateTime StarDtTime { get; set; }

        /// <summary>
        /// End Dt
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Vehicle Order By
        /// </summary>
        public VehicleOrderByColumn VehicleOrderBy
        {
            get
            {
                return (VehicleOrderByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
