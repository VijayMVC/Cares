using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Design Grade Search Request Response web model
    /// </summary>
    public class DesignGradeSearchRequestResponse
    {
        #region Public
        /// <summary>
        /// Design Grades List
        /// </summary>
        public IEnumerable<DesignGrade> DesignGrades { get; set; }

        /// <summary>
        /// Total Count of Design Grades
        /// </summary>
        public int TotalCount { get; set; }
        #endregion
    }
}