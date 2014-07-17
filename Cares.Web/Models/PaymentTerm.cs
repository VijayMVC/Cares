
namespace Cares.Web.Models
{
    /// <summary>
    /// Payment Term Api Model
    /// </summary>
    public class PaymentTerm
    {
        #region Public Properties
        /// <summary>
        /// PaymentTerm ID
        /// </summary>
        public int PaymentTermId { get; set; }
        /// <summary>
        /// PaymentTerm Code
        /// </summary>
        public string PaymentTermCode { get; set; }
        /// <summary>
        /// PaymentTerm Name
        /// </summary>
        public string PaymentTermName { get; set; }
        /// <summary>
        /// PaymentTerm Description
        /// </summary>
        public string PaymentTermDescription { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion
    }
}
