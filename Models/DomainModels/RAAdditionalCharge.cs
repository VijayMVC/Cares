using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// RAAdditional Charge Model
    /// </summary>
    public class RaAdditionalCharge
    {
        #region Persisted Properties
        
        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaAdditionalChargeId { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// AdditionalCharge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long? HireGroupDetailId { get; set; }

        /// <summary>
        /// Additional Charge Rate
        /// </summary>
        public double AdditionalChargeRate { get; set; }

        /// <summary>
        /// Plate Number
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public short Quantity { get; set; }
        
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
        /// Additional Charge Type
        /// </summary>
        public virtual AdditionalChargeType AdditionalChargeType { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        #endregion
    }
}
