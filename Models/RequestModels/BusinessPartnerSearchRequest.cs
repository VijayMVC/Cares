using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Partner Search Request Model
    /// </summary>
    public class BusinessPartnerSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Filter Option (Individual/Company), 1 for Individual , 2 for Company
        /// </summary>
        public bool? SelectOption { get; set; }
        /// <summary>
        /// BusinessPartner Order By
        /// </summary>
        public BusinessPartnerByColumn BusinessPartnerOrderBy
        {
            get
            {
                return (BusinessPartnerByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
