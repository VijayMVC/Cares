using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Hire Group Detail Request
    /// </summary>
    public sealed class HireGroupDetailRequest : GetPagedListRequest
    {   
         /// <summary>
        /// Hire Group ID
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }
        /// <summary>
        /// Vehicle Model Id
        /// </summary>
        public short  VehicleModelId { get; set; }
        /// <summary>
        /// Vehicle Category Id
        /// </summary>
        public short  VehicleCategoryId { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Tarrif type Order By
        /// </summary>
        public HireGroupDetailByColumn TarrifTypeByOrder
        {
            get
            {
                return (HireGroupDetailByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
                           
    }
}
