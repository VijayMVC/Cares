namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Drop Down
    /// </summary>
    public class HireGroupDropDown
    {
        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// Hire Group Code
        /// </summary>
        public string HireGroupCodeName { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public long? CompanyId { get; set; }
    }
}