using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Additional Driver Charge Domain Model
    /// </summary>
    public class AdditionalDriverCharge
    {
        #region Persisted Properties
        /// <summary>
        /// Additional Driver Charge ID
        /// </summary>
        public long AdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Child Additional Driver Charge ID
        /// </summary>
        public long? ChildAdditionalDriverChargeId { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Additional Driver Charge Rate
        /// </summary>
        public double AdditionalDriverChargeRate { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

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
        /// Child Additional Driver Charge
        /// </summary>
        public virtual AdditionalDriverCharge ChildAdditionalDriverCharge { get; set; }
        #endregion
    }
}
