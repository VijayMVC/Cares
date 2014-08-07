using Models.Common;

namespace Models.RequestModels
{
    /// <summary>
    /// Tariff Rate Request Domain Model
    /// </summary>
    public class TariffRateRequest : GetPagedListRequest
    {
        /// <summary>
        /// Tariff Type Id
        /// </summary>
        public int? TariffTypeId { get; set; }        
        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }
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
