using System.ComponentModel.DataAnnotations;

namespace Cares.Web.Models
{
    /// <summary>
    /// Department web model
    /// </summary>
    public class Department
    {
        #region Persisted Properties

        /// <summary>
        /// Department ID
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Department Code
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Department Code
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Department Description
        /// </summary>
        public string DepartmentDescription { get; set; }

        /// <summary>
        /// Department Type
        /// </summary>
        [Required]
        public string DepartmentType { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }

        #endregion
    }
}