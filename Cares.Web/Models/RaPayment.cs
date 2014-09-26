using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// RAPayment Model
    /// </summary>
    public class RaPayment
    {
        #region Persisted Properties

        /// <summary>
        /// RaPayment ID
        /// </summary>
        public long RaPaymentId { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Payment Mode
        /// </summary>
        public short PaymentModeId { get; set; }

        /// <summary>
        /// Ra Payment Dt
        /// </summary>
        public DateTime RaPaymentDt { get; set; }

        /// <summary>
        /// Ra Payment Amount
        /// </summary>
        public double RaPaymentAmount { get; set; }

        /// <summary>
        /// Cheque Number
        /// </summary>
        public string ChequeNumber { get; set; }

        /// <summary>
        /// Credit Card Number
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Issue Dt
        /// </summary>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Clearance Dt
        /// </summary>
        public DateTime? ClearanceDate { get; set; }

        /// <summary>
        /// Credit Card Type
        /// </summary>
        public string CreditCardType { get; set; }

        /// <summary>
        /// Bank
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// Credit Card Expiry Dt
        /// </summary>
        public DateTime? CreditCardExpiryDt { get; set; }

        /// <summary>
        /// Paid By
        /// </summary>
        public string PaidBy { get; set; }
        
        #endregion

    }
}