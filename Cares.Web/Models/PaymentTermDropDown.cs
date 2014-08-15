
namespace Cares.Web.Models
{
    /// <summary>
    /// Payment Term Dropdown Web Api Model
    /// </summary>
    public class PaymentTermDropDown
    {
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
        /// Vehicle Model Code Name
        /// </summary>
        public string PaymentTermNameCodeName
        {
            get
            {
                return string.Format("{0}-{1}", PaymentTermCode, PaymentTermName);
            }
        }
    }
}
