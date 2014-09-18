using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Designation Search Request model
    /// </summary>
    public class DesignationSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Designation code and name text
        /// </summary>
        public string DesignationFilterText { get; set; }


        /// <summary>
        /// Designation By Column for sorting
        /// </summary>
        public DesignationByColumn DesignationOrderBy
        {
            get
            {
                return (DesignationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
