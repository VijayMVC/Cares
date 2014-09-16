using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Insurance Rate Search Request
    /// </summary>
    public sealed class InsuranceRateSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Tariff Rate Id
        /// </summary>
        public int? TariffTypeId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }
        /// <summary>
        /// Insurance Rate Order By
        /// </summary>
        public InsuranceRateByColumn InsuranceRateByOrder
        {
            get
            {
                return (InsuranceRateByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
