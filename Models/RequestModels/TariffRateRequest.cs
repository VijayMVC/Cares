using Models.Common;

namespace Models.RequestModels
{
    /// <summary>
    /// Tariff Rate Request Domain Model
    /// </summary>
    public class TariffRateRequest : GetPagedListRequest
    {
        /// <summary>
        /// Tariff Rate Id
        /// </summary>
        public int? TariffRateId { get; set; }        
        /// <summary>
        /// Operation Id
        /// </summary>
        public int? OperationId { get; set; }
        /// <summary>
        /// Tarrif Rate Order By
        /// </summary>
        public TariffRateByColumn TariffRateByOrder
        {
            get
            {
                return (TariffRateByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
