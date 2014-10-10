using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Vehicle Make Search Request Model
    /// </summary>
    public class VehicleMakeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Vehicle make code and name for searching
        /// </summary>
        public string VehicleMakeCodeNameText { get; set; }

        /// <summary>
        ///  Vehicle Make By Column for sorting
        /// </summary>
        public VehicleMakeByColumn VehicleMakeOrderBy
        {

            get
            {
                return (VehicleMakeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
