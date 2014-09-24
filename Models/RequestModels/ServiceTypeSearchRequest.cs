using Cares.Models.Common;

namespace Cares.Models.RequestModels
{

    /// <summary>
    /// Service Type Search Request Model
    /// </summary>
    public class ServiceTypeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        ///  Service Type code and name text
        /// </summary>
        public string ServiceTypeFilterText { get; set; }

        /// <summary>
        ///  Service Type By Column for sorting
        /// </summary>
        public ServiceTypeByColumn ServiceTypeOrderBy
        {
            get
            {
                return (ServiceTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
