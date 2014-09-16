using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Region Search Request model
    /// </summary>
    public class RegionSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Region code and name text
        /// </summary>
        public string RegionFilterText { get; set; }

        /// <summary>
        /// country id
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Region By Column for sorting
        /// </summary>
        public RegionByColumn RegionOrderBy
        {
            get
            {
                return (RegionByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
