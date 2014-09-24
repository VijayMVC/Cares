using System;

namespace Cares.Models.DomainModels
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
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Payment Mode
        /// </summary>
        public virtual PaymentMode PaymentMode { get; set; }

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        #endregion
    }
}
