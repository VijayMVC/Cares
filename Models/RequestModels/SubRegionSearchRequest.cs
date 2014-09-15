using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Sub Region Search Request Model
    /// </summary>
    public class SubRegionSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Region code and name text
        /// </summary>
        public string SubRegionFilterText { get; set; }

        /// <summary>
        /// Region id
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        ///Sub Region By Column for sorting
        /// </summary>
        public SubRegionByColumn SubRegionOrderBy
        {
            get
            {
                return (SubRegionByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
