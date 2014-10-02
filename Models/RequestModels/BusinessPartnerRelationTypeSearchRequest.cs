using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Partner Relation Type Search Request Domain Model
    /// </summary>
    public class BusinessPartnerRelationTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Business Partner Relation Type code and name text
        /// </summary>
        public string BusinessPartnerRelationTypeFilterText { get; set; }

        /// <summary>
        ///  Business Partner Relation Type By Column for sorting
        /// </summary>
        public BusinessPartnerRelationTypeByColumn BusinessPartnerRelationTypeGroupOrderBy
        {
            get
            {
                return (BusinessPartnerRelationTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
