using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Maintenece Type Group Search Request Model
    /// </summary>
    public class MainteneceTypeGroupSearchRequest:GetPagedListRequest
    {
        /// <summary>
        ///  Maintenece Type Group code and name text
        /// </summary>
        public string MainteneceTypeGroupFilterText { get; set; }

        /// <summary>
        ///  Maintenece Type Group By Column for sorting
        /// </summary>
        public MainteneceTypeGroupByColumn MainteneceTypeGroupOrderBy
        {
            get
            {
                return (MainteneceTypeGroupByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
