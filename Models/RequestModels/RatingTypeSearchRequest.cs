
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Rating Type Search Request domain model
    /// </summary>
    public class RatingTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Rating Type code and name text
        /// </summary>
        public string RatingTypeFilterText { get; set; }

      
        /// <summary>
        /// Rating Type By Column for sorting
        /// </summary>
        public RatingTypeByColumn RatingTypeOrderBy
        {
            get
            {
                return (RatingTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
