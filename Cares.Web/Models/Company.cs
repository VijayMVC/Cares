namespace Cares.Web.Models
{
    /// <summary>
    /// Company Web Model
    /// </summary>
    public class Company
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
        /// Company Code
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
      
    }
}