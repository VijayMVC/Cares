using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Chauffer Charge Search Request
    /// </summary>
    public sealed class ChaufferChargeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long? TariffTypeId { get; set; }

        /// <summary>
        /// ChaufferC harge By Order
        /// </summary>
        public ChaufferChargeByColumn ChaufferChargeOrderBy
        {
            get
            {
                return (ChaufferChargeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
