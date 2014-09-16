using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Department Search Request
    /// </summary>
    public class DepartmentSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// DepartmentCode
        /// </summary>
        public string DepartmentFilterText { get; set; }

        /// <summary>
        /// DepartmentType
        /// </summary>
        public string DepartmentTypeText { get; set; }

        /// <summary>
        /// CompanyId
        /// </summary>
        public int? CompanyId { get; set; }


        public DepartmentByColumn OperationOrderBy
        {
            get
            {
                return (DepartmentByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
