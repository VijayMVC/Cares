using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Credit Limit Search Request model
    /// </summary>
    public class CreditLimitSearchRequest:GetPagedListRequest
    {
       
        /// <summary>
        /// Bp Sub Type id
        /// </summary>
        public int? BpSubTypeId { get; set; }

        /// <summary>
        /// Rating Type Id 
        /// </summary>
        public int? RatingTypeId { get; set; }

        /// <summary>
        /// Credit Limit By Column for sorting
        /// </summary>
        public CreditLimitByColumn CreditLimitOrderBy
        {
            get
            {
                return (CreditLimitByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
