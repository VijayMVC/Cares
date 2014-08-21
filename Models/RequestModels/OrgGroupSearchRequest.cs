using Cares.Models.Common;
namespace Cares.Models.RequestModels
{
   public class OrgGroupSearchRequest : GetPagedListRequest
    {
       /// <summary>
       /// Org Group Code
       /// </summary>
        public string OrgGroupCode { get; set; }
        /// <summary>
        /// Org Group Name
        /// </summary>
        public string OrgGroupName { get; set; }
        public OrgGroupByColumn OrgGroupOrderBy
        {
            get
            {
                return (OrgGroupByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }

    }
}
