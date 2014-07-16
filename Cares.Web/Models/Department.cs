namespace Cares.Web.Models
{
    /// <summary>
    /// Department Model
    /// </summary>
    public class Department
    {
        #region Public Properties
        /// <summary>
        /// Department ID
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Department Code
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        #endregion
    }
}