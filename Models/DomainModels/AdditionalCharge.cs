using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Additional Charge Domain Model
    /// </summary>
    public class AdditionalCharge
    {
        #region Persisted Properties

        /// <summary>
        /// Additional Charge ID
        /// </summary>
        public long AdditionalChargeId { get; set; }

        /// <summary>
        /// Child Additional Charge ID
        /// </summary>
        public long? ChildAdditionalChargeId { get; set; }

        /// <summary>
        /// Additional Charge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long? HireGroupDetailId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Additional Charge Rate
        /// </summary>
        public double? AdditionalChargeRate { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long? RevisionNumber { get; set; }

        
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
        public virtual AdditionalCharge ChildAdditionalCharge { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Additional Charge Type
        /// </summary>
        public virtual AdditionalChargeType AdditionalChargeType { get; set; }

        #endregion
    }
}
