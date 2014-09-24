using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Discount Sub Type Search Request Model
    /// </summary>
    public class DiscountSubTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Discount Sub Type code and name text
        /// </summary>
        public string DiscountSubTypeFilterText { get; set; }

        /// <summary>
        /// Discount Type Id
        /// </summary>
        public int? DiscountTypeId { get; set; }

        /// <summary>
        /// Discount Sub Type By Column for sorting
        /// </summary>
        public DiscountSubTypeByColumn DiscountSubTypeOrderBy
        {
            get
            {
                return (DiscountSubTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
