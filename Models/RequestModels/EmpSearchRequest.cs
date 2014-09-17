using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Employee Status search reqiest model
    /// </summary>
    public class EmpSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Employee Status code and name text
        /// </summary>
        public string EmpFilterText { get; set; }

        /// <summary>
        /// Employee Status By Column for sorting
        /// </summary>
        public EmpStatusByColumn EmpStatusOrderBy
        {
            get
            {
                return (EmpStatusByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
