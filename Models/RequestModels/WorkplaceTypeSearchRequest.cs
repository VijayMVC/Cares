using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Work place Type Search Request
    /// </summary>
    public class WorkplaceTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Filter text
        /// </summary>
        public string WorkplaceTypeFilterText { get; set; }

        /// <summary>
        ///  WorkplaceType By Column for sorting
        /// </summary>
        public WorkplaceTypeByColumn WorkplaceTypeOrderBy
        {

            get
            {
                return (WorkplaceTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
