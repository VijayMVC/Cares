namespace Cares.Web.Models
{
    /// <summary>
    /// Parent Hire Group Web Model
    /// </summary>
    public class ParentHireGroup
    {
        /// <summary>
        /// Parent Hire Group Id
        /// </summary>
        public long ParentHireGroupId { get; set; }
        /// <summary>
        /// Parent Hire Name
        /// </summary>
        public string ParentHireGroupName { get; set; }
        /// <summary>
        /// Parent Hire Group Id
        /// </summary>
        public long? CompanyId { get; set; }
    }
}