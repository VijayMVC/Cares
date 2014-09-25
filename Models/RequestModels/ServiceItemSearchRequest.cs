using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Service Item Search Request Model
    /// </summary>
    public class ServiceItemSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Service Item code and name text
        /// </summary>
        public string ServiceItemFilterText { get; set; }

        /// <summary>
        /// Service Type id
        /// </summary>
        public int? ServiceTypeId { get; set; }

        /// <summary>
        /// Service Item By Column for sorting
        /// </summary>
        public ServiceItemByColumn ServiceItemOrderBy
        {
            get
            {
                return (ServiceItemByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
