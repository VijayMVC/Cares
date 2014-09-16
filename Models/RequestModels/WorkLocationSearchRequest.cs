using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Work Location Search Request
    /// </summary>
    public class WorkLocationSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Declarations
        /// </summary>
        public string WorkLocationFilterText { get; set; }
        public long? CityId { get; set; }
        public long? AreaId { get; set; }


        /// <summary>
        /// Work Location By Column for sorting
        /// </summary>
        public WorkLocationByColumn WorkLocationOrderBy
        {
            get
            {
                return (WorkLocationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
