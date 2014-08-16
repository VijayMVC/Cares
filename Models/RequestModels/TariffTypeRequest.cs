using Cares.Models.Common;
using Cares.Models.DomainModels;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// tariffT ype Request
    /// </summary>
    public class TariffTypeRequest:GetPagedListRequest
    {
        /// <summary>
        /// tariff Type Code
        /// </summary>
        public string TariffTypeCode  { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// Measurement Unit Id
        /// </summary>
        public int MeasurementUnitId  { get; set; }
        /// <summary>
        /// tariff Type Name
        /// </summary>
        public string TariffTypeName { get; set; }
        /// <summary>
        /// Department Id
        /// </summary>
        public long DepartmentId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }
        /// <summary>
        /// tariff Type
        /// </summary>
        public TariffType TariffType { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// tariff type Order By
        /// </summary>
        public TariffTypeByColumn TariffTypeByOrder
        {
            get
            {
                return (TariffTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
