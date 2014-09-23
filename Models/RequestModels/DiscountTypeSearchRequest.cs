
using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Discount Type Search Request Model
    /// </summary>
    public class DiscountTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        ///  Discount Type code and name text
        /// </summary>
        public string DiscountTypeFilterText { get; set; }

        /// <summary>
        ///  Discount Type By Column for sorting
        /// </summary>
        public DiscountTypeByColumn DiscountTypeOrderBy
        {
            get
            {
                return (DiscountTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
