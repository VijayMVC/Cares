using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// operation search request 
    /// </summary>
    public class OperationSearchRequest : GetPagedListRequest
    {
        public string OperationFilterText { get; set; }
        public string DepartmentTypeText { get; set; }

        /// <summary>
        /// Operation By Column to sort the data
        /// </summary>
        public OperationByColumn OperationOrderBy
        {
            get
            {
                return (OperationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
