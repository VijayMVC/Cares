

using Models.Common;

namespace Models.RequestModels
{
    /// <summary>
    /// Tariff Rate Detail Request
    /// </summary>
    public sealed class TariffRateDetailRequest:GetPagedListRequest
    {
        /// <summary>
        /// Standard Rate Main Id
        /// </summary>
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
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
