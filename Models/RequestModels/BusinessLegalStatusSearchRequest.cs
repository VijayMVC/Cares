using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Business Legal Status Search Request Model
    /// </summary>
    public class BusinessLegalStatusSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Business Legal Status code and name
        /// </summary>
        public string BusinessLegalStatusSearchText { get; set; }
       
        /// <summary>
        /// BusinessLegalStatus By Column for sorting
        /// </summary>
        public BusinessLegalStatusByColumn BusinessLegalStatusOrderBy
        {

            get
            {
                return (BusinessLegalStatusByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
