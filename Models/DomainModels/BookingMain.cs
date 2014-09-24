using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Booking Main Model
    /// </summary>
    public class BookingMain
    {
        #region Persisted Properties
        
        /// <summary>
        /// Booking Main ID
        /// </summary>
        public long BookingMainId { get; set; }

        /// <summary>
        /// Open Location
        /// </summary>
        public long OpenLocation { get; set; }

        /// <summary>
        /// Close Location
        /// </summary>
        public long CloseLocation { get; set; }

        /// <summary>
        /// Booking Status Id
        /// </summary>
        public short BookingStatusId { get; set; }

        /// <summary>
        /// Payment Term Id
        /// </summary>
        public short PaymentTermId { get; set; }

        /// <summary>
        /// Operatiom Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Booking Main Description
        /// </summary>
        public string BookingMainDescription { get; set; }
        
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

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
        /// Booking Status
        /// </summary>
        public virtual AdditionalCharge BookingStatus { get; set; }

        /// <summary>
        /// Payment Term
        /// </summary>
        public virtual PaymentTerm PaymentTerm { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Operations Workplace Open
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlaceOpen { get; set; }

        /// <summary>
        /// OperationsWorkPlace Close
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlaceClose { get; set; }

        /// <summary>
        /// Vehicle Reservations
        /// </summary>
        public virtual ICollection<VehicleReservation> VehicleReservations { get; set; }

        /// <summary>
        /// Chauffer Reservations
        /// </summary>
        public virtual ICollection<ChaufferReservation> ChaufferReservations { get; set; }

        #endregion
    }
}
