using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Category Search Request Model
    /// </summary>
    public class VehicleCategorySearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Vehicle Category code and name text
        /// </summary>
        public string VehicleCategoryFilterText { get; set; }

        /// <summary>
        /// Vehicle Category By Column for sorting
        /// </summary>
        public VehicleCategoryByColumn VehicleCategoryOrderBy
        {
            get
            {
                return (VehicleCategoryByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
