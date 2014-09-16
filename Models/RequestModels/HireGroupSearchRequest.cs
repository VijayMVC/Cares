using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Hire Group Domain Model Request
    /// </summary>
    public sealed class HireGroupSearchRequest : GetPagedListRequest
    {
           
        /// <summary>
        /// Company Id
        /// </summary>
        public long? CompanyId { get; set; }
        
        /// <summary>
        /// Parent Hire Group ID
        /// </summary>
        public long? ParentHireGroupId { get; set; }
       
        /// <summary>
        /// Hire Group Order By
        /// </summary>
        public HireGroupByColumn HireGroupOrderBy
        {
            get
            {
                return (HireGroupByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
