using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Status Search Request Model
    /// </summary>
    public class VehicleStatusSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Vehicle Status Name and Code Search
        /// </summary>
        public string VehicleStatusCodeNameFilterText { get; set; }

        /// <summary>
        /// Vehicle Status By Column For Sorting
        /// </summary>
        public VehicleStatusByColumn VehicleStatusOrderBy
        {
            get
            {
                return (VehicleStatusByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
