namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Web Model
    /// </summary>
    public class HireGroup
    {
        #region Public Properties
        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// Hire Group Code
        /// </summary>
        public string HireGroupCode { get; set; }
        /// <summary>
        /// Hire Group Name
        /// </summary>
        public string HireGroupName { get; set; }
        /// <summary>
        /// Parent Hire Group Id
        /// </summary>
        public long? ParentHireGroupId { get; set; }
        /// <summary>
        /// Parent Hire Group Name
        /// </summary>
        public string ParentHireGroupName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Is Parent
        /// </summary>
        public bool IsParent { get; set; }
        #endregion

    }
}