
namespace Cares.Web.Models
{
    /// <summary>
    /// Employee status web model
    /// </summary>
    public class EmpStatus
    {
        /// <summary>
        /// Employee Status ID
        /// </summary>
        public long EmpStatusId { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        public string EmpStatusCode { get; set; }

        /// <summary>
        /// Employee Satus Code
        /// </summary>
        public string EmpStatusName { get; set; }

        /// <summary>
        /// Employee Satus Description
        /// </summary>
        public string EmpStatusDescription { get; set; }

        /// <summary>
        /// Employee Satus Flag
        /// </summary>
        public bool EmpStatusFlag { get; set; }
    }
}