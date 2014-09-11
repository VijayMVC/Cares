using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    public class EmployeeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Employee Status Id
        /// </summary>
        public long? EmployeeStatusId { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public long? CompanyId { get; set; }

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
