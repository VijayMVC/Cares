using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Job Type Search Request Model
    /// </summary>
    public class JobTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        ///  Job Type code and name text
        /// </summary>
        public string JobTypeFilterText { get; set; }

        /// <summary>
        ///  Job Type By Column for sorting
        /// </summary>
        public JobTypeByColumn JobTypeOrderBy
        {
            get
            {
                return (JobTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
