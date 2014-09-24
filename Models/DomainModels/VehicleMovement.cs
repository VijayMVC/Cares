using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Movement Model
    /// </summary>
    public class VehicleMovement
    {
        #region Persisted Properties
        
        /// <summary>
        ///  Vehicle ID
        /// </summary>
        public long VehicleMovementId { get; set; }

        /// <summary>
        /// Operations Workplace ID
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        ///  Ra HireGroup ID
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short? VehicleStatusId { get; set; }

        /// <summary>
        /// DtTime
        /// </summary>
        public DateTime DtTime { get; set; }

        /// <summary>
        /// Odometer
        /// </summary>
        public int? Odometer { get; set; }

        /// <summary>
        /// Fuel Level
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// Vehicle Movement Description
        /// </summary>
        public string VehicleMovementDescription { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Vehicle Condition Description
        /// </summary>
        public string VehicleConditionDescription { get; set; }

        /// <summary>
        /// Vehicle Condition
        /// </summary>
        public string VehicleCondition { get; set; }
        
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
        ///  Ra HireGroup
        /// </summary>
        public virtual RaHireGroup RaHireGroup { get; set; }

        /// <summary>
        /// Operations Workplace
        /// </summary>
        public virtual OperationsWorkPlace OperationsWorkPlace { get; set; }

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public virtual VehicleStatus VehicleStatus { get; set; }

        #endregion
    }
}
