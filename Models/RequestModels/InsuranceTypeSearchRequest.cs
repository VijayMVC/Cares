using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Insurance Type Search Request Model
    /// </summary>
    public class InsuranceTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Insurance Type code and name search
        /// </summary>
        public string InsuranceTypeCodeNameText { get; set; }
       
        /// <summary>
        /// Insurance Type By Column for sorting
        /// </summary>
        public InsuranceTypeByColumn InsuranceTypeOrderBy
        {

            get
            {
                return (InsuranceTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
