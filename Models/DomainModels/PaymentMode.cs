using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Payment Mode Domain Model
    /// </summary>
    public class PaymentMode
    {
        #region Persisted Properties
        
        /// <summary>
        /// Payment Mode ID
        /// </summary>
        public short PaymentModeId { get; set; }

        /// <summary>
        /// Payment Mode Code
        /// </summary>
        public string PaymentModeCode { get; set; }

        /// <summary>
        /// Payment Mode Name
        /// </summary>
        public string PaymentModeName { get; set; }

        /// <summary>
        /// Payment Mode Description
        /// </summary>
        public string PaymentModeDescription { get; set; }

        /// <summary>
        /// Payment Mode Key
        /// </summary>
        public short? PaymentModeKey { get; set; }
        
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
        /// Ra Payments
        /// </summary>
        public virtual ICollection<RaPayment> RaPayments { get; set; }

        #endregion
    }
}
