using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Occupation Type Search Request model
    /// </summary>
    public class OccupationTypeSearchRequest:GetPagedListRequest
    {
        /// <summary>
        /// Occupation Type Code and Name search filter
        /// </summary>
        public string OccupationTypeCodeNameText { get; set; }
       
        /// <summary>
        ///  Occupation Type By Column for sorting
        /// </summary>
        public OccupationTypeByColumn OccupationTypeOrderBy
        {
            get
            {
                return (OccupationTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
