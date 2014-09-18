using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// City Search Request model
    /// </summary>
    public class CitySearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// City code and name text
        /// </summary>
        public string CityFilterText { get; set; }

        /// <summary>
        /// country id
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// City By Column for sorting
        /// </summary>
        public CityByColumn CityOrderBy
        {
            get
            {
                return (CityByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
