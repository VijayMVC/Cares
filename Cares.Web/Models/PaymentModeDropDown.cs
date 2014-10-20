namespace Cares.Web.Models
{
    /// <summary>
    /// Payment Mode Web Model
    /// </summary>
    public class PaymentModeDropDown
    {
        #region Public

        /// <summary>
        /// Payment Mode ID
        /// </summary>
        public short PaymentModeId { get; set; }

        /// <summary>
        /// Payment Mode Code Name
        /// </summary>
        public string PaymentModeCodeName { get; set; }

        /// <summary>
        /// Payment Mode Key
        /// </summary>
        public short? PaymentModeKey { get; set; }

        #endregion
    }
}