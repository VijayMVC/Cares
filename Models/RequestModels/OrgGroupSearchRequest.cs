using Cares.Models.Common;
namespace Cares.Models.RequestModels
{
   public class OrgGroupSearchRequest : GetPagedListRequest
    {
       /// <summary>
       /// Org Group Code
       /// </summary>
        public string OrgGroupText { get; set; }
       
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
