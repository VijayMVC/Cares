
using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Design Grade Web model
    /// </summary>
    public class DesignGrade
    {
        /// <summary>
        /// Designation Grade ID
        /// </summary>

   
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Designation Grade Code
        /// </summary>
        public string DesigGradeCode { get; set; }

        /// <summary>
        /// Designation Grade Code
        /// </summary>
        public string DesigGradeName { get; set; }

        /// <summary>
        /// Designation Grade Description
        /// </summary>
        public string DesigGradeDescription { get; set; }
    }
}