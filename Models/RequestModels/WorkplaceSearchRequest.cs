using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// workplace search request
    /// </summary>
    public class WorkplaceSearchRequest : GetPagedListRequest
    {

        public string WorkplaceFilterText { get; set; }

        public int? WorkplaceTypeId { get; set; }

        public int? CompanyId { get; set; }

        /// <summary>
        ///Workplace By Column To sort the Workplace data
        /// </summary>
        public WorkplaceByColumn WorkplaceOrderBy
        {
            get { return (WorkplaceByColumn)SortBy; }
            set { SortBy = (short)value; }
        }
    }
}
