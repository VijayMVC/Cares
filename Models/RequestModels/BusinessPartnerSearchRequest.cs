
using Models.Common;

namespace Models.RequestModels
{
    /// <summary>
    /// Business Partner Search Request Model
    /// </summary>
    public class BusinessPartnerSearchRequest : GetPagedListRequest
    {
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
