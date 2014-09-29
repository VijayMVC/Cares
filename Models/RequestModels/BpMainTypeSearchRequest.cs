using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Bp Main Type Search Request Model
    /// </summary>
    public class BpMainTypeSearchRequest :GetPagedListRequest
    {
        /// <summary>
        ///Bp Main Type code and name text
        /// </summary>
        public string BpMainTypeFilterText { get; set; }

        /// <summary>
        ///Bp Main Type By Column for sorting
        /// </summary>
        public BpMainTypeByColumn BpMainTypeOrderBy
        {
            get
            {
                return (BpMainTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
