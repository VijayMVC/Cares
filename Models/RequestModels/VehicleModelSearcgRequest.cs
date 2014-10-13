using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
   public class VehicleModelSearcgRequest:GetPagedListRequest
    {
       /// <summary>
       /// Vehicle model code and name filter text for search
       /// </summary>
       public string VehicleModelCodeNameFilterText { get; set; }
      
        /// <summary>
        /// Vehicle Model By Column for sorting
        /// </summary>
        public VehicleModelByColumn VehicleModelOrderBy
        {

            get
            {
                return (VehicleModelByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
