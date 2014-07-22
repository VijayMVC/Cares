using Models.Common;
using Models.DomainModels;

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
        public string TariffTypeId { get; set; }
        /// <summary>
        /// Tariff Rate Code
        /// </summary>
        public string TariffRateCode { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Tarrif Rate Name
        /// </summary>
        public string TariffRateName { get; set; }
        /// <summary>
        /// Department Id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }
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
