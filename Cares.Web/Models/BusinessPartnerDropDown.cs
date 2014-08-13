namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Dropdown Web Api Model
    /// </summary>
    public sealed class BusinessPartnerDropDown
    {
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerCodeName { get; set; }
    }
}