namespace Cares.Web.Models
{
    /// <summary>
    /// Company DropDown Web Api Model
    /// </summary>
    public class CompanyDropDown
    {
        /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// Parent Company
        /// </summary>
        public long? ParentCompanyId { get; set; }
        /// <summary>
        /// Organization Group ID
        /// </summary>
        public int OrgGroupId { get; set; }
        /// <summary>
        /// Company Code Name
        /// </summary>
        public string CompanyCodeName { get; set; }
    }
}