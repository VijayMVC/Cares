using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Domain Model Request
    /// </summary>
    public sealed class VehicleSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupId { get; set; }
        
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
