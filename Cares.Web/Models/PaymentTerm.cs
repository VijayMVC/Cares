
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
        public short PaymentTermId { get; set; }
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
        /// PaymentTerm Code Name
        /// </summary>
        public string PaymentTermCodeName {
            get
            {
                return string.Format("{0}-{1}", PaymentTermCode, PaymentTermName);
            } 
        }

        #endregion
    }
}
