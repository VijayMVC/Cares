using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Marketing Channel Search Request Model
    /// </summary>
    public class MarketingChannelSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Marketing Channel code and name text
        /// </summary>
        public string MarketingChannelFilterText { get; set; }

        
        /// <summary>
        /// Marketing Channel By Column for sorting
        /// </summary>
        public MarketingChannelByColumn MarketingChannelOrderBy
        {
            get
            {
                return (MarketingChannelByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
