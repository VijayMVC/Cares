namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Status Drop Down
    /// </summary>
    public sealed class EmpStatusDropDown
    {
        /// <summary>
        /// Employee StatusId
        /// </summary>
        public long EmpStatusId { get; set; }
       
        /// <summary>
        /// Employee Status Code Name
        /// </summary>
        public string EmpStatusCodeName { get; set; }
    }
}