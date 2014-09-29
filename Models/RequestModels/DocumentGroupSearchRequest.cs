using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Document Group Search Request model
    /// </summary>
    public class DocumentGroupSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Document Group code and name text
        /// </summary>
        public string DocumentGroupFilterText { get; set; }

        /// <summary>
        /// Document Group By Column for sorting
        /// </summary>
        public DocumentGroupByColumn DocumentGroupOrderBy
        {
            get
            {
                return (DocumentGroupByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
