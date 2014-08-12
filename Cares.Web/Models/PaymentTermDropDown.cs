
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
        /// PaymentTerm Code and  Name
        /// </summary>
        public string PaymentTermCodeName { get; set; }
    }
}
