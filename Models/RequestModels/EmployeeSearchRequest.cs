using Models.Common;

namespace Models.RequestModels
{
    public class EmployeeSearchRequest : GetPagedListRequest
    {
        public long? DepartmentId { get; set; }

        /// <summary>
        /// Employee Order By
        /// </summary>
        public EmployeeByColumn EmployeeOrderBy
        {
            get
            {
                return (EmployeeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
