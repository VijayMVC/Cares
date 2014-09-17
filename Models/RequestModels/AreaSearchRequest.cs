using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Area Search Request model
    /// </summary>
    public class AreaSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Area code and name text
        /// </summary>
        public string AreaFilterText { get; set; }

        /// <summary>
        /// City id
        /// </summary>
        public int? CityId { get; set; }

        /// <summary>
        /// Area By Column for sorting
        /// </summary>
        public AreaByColumn AreaOrderBy
        {
            get
            {
                return (AreaByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
