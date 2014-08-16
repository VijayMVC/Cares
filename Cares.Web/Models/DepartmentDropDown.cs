namespace Cares.Web.Models
{
    /// <summary>
    /// Department Model
    /// </summary>
    public class DepartmentDropDown
    {
        #region Public Properties
        /// <summary>
        /// Department ID
        /// </summary>
        public long DepartmentId { get; set; }
        /// <summary>
        /// Department Code
        /// </summary>
        public string DepartmentCodeName { get; set; }
        /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }
    
        #endregion
    }
}