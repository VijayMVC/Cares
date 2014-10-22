using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Payment Domain Model
    /// </summary>
    public class BookingPayment
    {
        #region Public Properties

        /// <summary>
        /// Booking Payment ID 
        /// </summary>
        public long BookingPaymentId { get; set; }

        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Payment ModeI D
        /// </summary>
        public long PaymentModeId { get; set; }

        /// <summary>
        /// Booking Payment Dt
        /// </summary>
        public DateTime BookingPaymentDt { get; set; }

        /// <summary>
        /// Booking Payment Amount
        /// </summary>
        public float BookingPaymentAmount { get; set; }

        /// <summary>
        /// Cheque Number
        /// </summary>
        public string ChequeNumber { get; set; }

        /// <summary>
        /// Issue Date
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Clearance Date
        /// </summary>
        public DateTime ClearanceDate { get; set; }

        /// <summary>
        /// Bank
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// Credit Card Expiry Dt
        /// </summary>
        public DateTime CreditCardExpiryDt { get; set; }

        /// <summary>
        /// Paid By
        /// </summary>
        public string PaidBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Booking Main
        /// </summary>
        public virtual BookingMain BookingMain { get; set; }

        /// <summary>
        /// Payment Mode
        /// </summary>
        public virtual PaymentMode PaymentMode { get; set; }

        #endregion
    }
}
