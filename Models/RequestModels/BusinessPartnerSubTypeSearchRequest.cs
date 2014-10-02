using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Partner Sub Type Search Request Model
    /// </summary>
    public class BusinessPartnerSubTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Business Partner Sub Type code and name
        /// </summary>
        public string BusinessPartnerSubTypeCodeNameText { get; set; }

        /// <summary>
        /// Business Partner Main Type Id
        /// </summary>
        public int? BusinessPartnerMainTypeId { get; set; }

        /// <summary>
        ///   Business Partner Sub Type By Column for sorting
        /// </summary>
        public BusinessPartnerSubTypeByColumn BusinessPartnerSubTypeOrderBy
        {

            get
            {
                return (BusinessPartnerSubTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
