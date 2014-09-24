using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// NrtCharge Model
    /// </summary>
    public class NrtCharge
    {
        #region Persisted Properties
        
        /// <summary>
        /// NrtCharge ID
        /// </summary>
        public long NrtChargeId { get; set; }

        /// <summary>
        /// Total NRT Charge Rate
        /// </summary>
        public double TotalNrtChargeRate { get; set; }

        /// <summary>
        /// AdditionalCharge Type ID
        /// </summary>
        public short AdditionalChargeTypeId { get; set; }

        /// <summary>
        /// NRT Vehicle ID
        /// </summary>
        public long NrtVehicleId { get; set; }

        /// <summary>
        /// Contact Person
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// NRT Charge Rate
        /// </summary>
        public double NrtChargeRate { get; set; }

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
        /// NRT Vehicle 
        /// </summary>
        public virtual NrtVehicle NrtVehicle { get; set; }

        #endregion
    }
}
