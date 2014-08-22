using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    public class DepartmentSearchRequest : GetPagedListRequest
    {
        public string DepartmentCodeText { get; set; }

        public string DepartmentNameText { get; set; }

        public string DepartmentTypeText { get; set; }

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
