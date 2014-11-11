using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Payment Term Domain Model
    /// </summary>
    public class PaymentTerm
    {
        #region Persisted Properties
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
        /// PaymentTerm Key
        /// </summary>
        public short? PaymentTermKey { get; set; }
        /// <summary>
        /// PaymentTerm Description
        /// </summary>
        public string PaymentTermDescription { get; set; }
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
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partners having this Payment Term
        /// </summary>
        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; }

        /// <summary>
        /// Ra Mains
        /// </summary>
        public virtual ICollection<RaMain> RaMains { get; set; }

        /// <summary>
        /// Booking Mains
        /// </summary>
        public virtual ICollection<BookingMain> BookingMains { get; set; }
        
        #endregion
    }
}
