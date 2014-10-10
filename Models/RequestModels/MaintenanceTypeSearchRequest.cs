using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Maintenance Type Search Request Model
    /// </summary>
    public class MaintenanceTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        ///  Maintenance Type code and name for searching
        /// </summary>
        public string MaintenanceTypeCodeNameText { get; set; }

        /// <summary>
        ///  Maintenance Type Groyp Id
        /// </summary>
        public int? MaintenanceTypeGroypId { get; set; }

        /// <summary>
        ///  Maintenance Type By Column for sorting
        /// </summary>
        public MaintenanceTypeByColumn MaintenanceTypeOrderBy
        {
            get
            {
                return (MaintenanceTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
