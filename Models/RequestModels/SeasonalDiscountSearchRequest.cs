using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Seasonal Discount Domain Search Request Model
    /// </summary>
    public sealed class SeasonalDiscountSearchRequest : GetPagedListRequest
    {

        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public long? TariffTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? OperationId { get; set; }

        /// <summary>
        /// Seasonal Discount By Order
        /// </summary>
        public SeasonalDiscountByColumn SeasonalDiscountOrderBy
        {
            get
            {
                return (SeasonalDiscountByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
