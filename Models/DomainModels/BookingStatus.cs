using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Status Model
    /// </summary>
    public class BookingStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Booking Status ID
        /// </summary>
        public short BookingStatusId { get; set; }

        /// <summary>
        /// Booking Status Code
        /// </summary>
        public string BookingStatusCode { get; set; }

        /// <summary>
        /// Booking Status Name
        /// </summary>
        public string BookingStatusName { get; set; }

        /// <summary>
        /// Booking Status Description
        /// </summary>
        public string BookingStatusDescription { get; set; }

        /// <summary>
        /// Booking Status Category
        /// </summary>
        public short? BookingStatusCat { get; set; }
        
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
        /// Booking Mains
        /// </summary>
        public virtual ICollection<BookingMain> BookingMains { get; set; }

        /// <summary>
        /// Hire Group Detaill
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        #endregion
    }
}
