using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Additional Charge Search Request
    /// </summary>
    public sealed class AdditionalChargeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Additional Driver Charge By Order
        /// </summary>
        public AdditionalChargeByColumn AdditionalChargeOrderBy
        {
            get
            {
                return (AdditionalChargeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
