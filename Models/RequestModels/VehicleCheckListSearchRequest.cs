using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Check List SearchR equest model
    /// </summary>
    public class VehicleCheckListSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Vehicle Check List code and name text
        /// </summary>
        public string VehicleCheckListFilterText { get; set; }

       
        /// <summary>
        /// Vehicle Check List By Column for sorting
        /// </summary>
        public VehicleCheckListByColumn VehicleCheckListOrderBy
        {
            get
            {
                return (VehicleCheckListByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
