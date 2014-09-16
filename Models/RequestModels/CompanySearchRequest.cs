using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Company Search Request
    /// </summary>
    public class CompanySearchRequest : GetPagedListRequest
    {
        public string CompanyText { get; set; }
        public int? OrganizationGroupId  { get; set; }
        public int? BusinessSegmentId  { get; set; }
        /// <summary>
        /// Company By Column for sorting
        /// </summary>
        public CompanyByColumn CompanyOrderBy
        {
            
            get
            {
                return (CompanyByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
