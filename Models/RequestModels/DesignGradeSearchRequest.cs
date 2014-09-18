using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Desig Grade Search Request Model
    /// </summary>
    public class DesignGradeSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Desig Grade code and name text
        /// </summary>
        public string DesigGradeFilterText { get; set; }

        /// <summary>
        /// Desig Grade By Column for sorting
        /// </summary>
        public DesignGradeByColumn DesignGradeOrderBy
        {
            get
            {
                return (DesignGradeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
