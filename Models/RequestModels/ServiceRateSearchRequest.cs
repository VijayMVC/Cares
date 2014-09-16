using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Service Rate Search Domain Request
    /// </summary>
    public sealed class ServiceRateSearchRequest : GetPagedListRequest
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
        /// Service Rate Order By
        /// </summary>
        public ServiceRateByColumn ServiceRateByOrder
        {
            get
            {
                return (ServiceRateByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
