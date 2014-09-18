using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    public class AdditionalDriverChargeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }

        /// <summary>
        /// tariff Type ID
        /// </summary>
        public long? TariffTypeId { get; set; }

        /// <summary>
        /// Additional Driver Charge By Order
        /// </summary>
        public AdditionalDriverChargeByColumn AdditionalDriverChargeByOrder
        {
            get
            {
                return (AdditionalDriverChargeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
