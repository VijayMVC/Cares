using Cares.Models.Common;
namespace Cares.Models.RequestModels
{
   public class OrgGroupSearchRequest : GetPagedListRequest
    {
        public string OrgGroupCode { get; set; }
        /// <summary>
        /// Operation Id
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
