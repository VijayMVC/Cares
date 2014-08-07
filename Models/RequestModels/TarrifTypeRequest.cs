using Cares.Models.Common;
using Cares.Models.DomainModels;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// TarrifT ype Request
    /// </summary>
    public class TarrifTypeRequest:GetPagedListRequest
    {
        /// <summary>
        /// Tarrif Type Code
        /// </summary>
        public string TarrifTypeCode  { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Measurement Unit Id
        /// </summary>
        public int MeasurementUnitId  { get; set; }
        /// <summary>
        /// Tarrif Type Name
        /// </summary>
        public string TarrifTypeName { get; set; }
        /// <summary>
        /// Department Id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Tarrif Type
        /// </summary>
        public TarrifType TarrifType { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Tarrif type Order By
        /// </summary>
        public TarrifTypeByColumn TarrifTypeByOrder
        {
            get
            {
                return (TarrifTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
