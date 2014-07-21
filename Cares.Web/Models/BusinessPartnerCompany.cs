namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Company Web Api Model
    /// </summary>
    public class BusinessPartnerCompany
    {
        #region Public Properties
        
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Company Code
        /// </summary>
        public string BusinessPartnerCompanyCode { get; set; }
        /// <summary>
        /// Business Partner Company Name
        /// </summary>
        public string BusinessPartnerCompanyName { get; set; }

        #endregion
    }
}