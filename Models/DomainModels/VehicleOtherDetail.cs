using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Other Detail Domain Model
    /// </summary>
    public class VehicleOtherDetail
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Number Of Doors
        /// </summary>
        public short? NumberOfDoors { get; set; }

        /// <summary>
        /// Horse Power_CC
        /// </summary>
        public short HorsePower_CC { get; set; }

        /// <summary>
        /// Number Of Cylinders
        /// </summary>
        public short? NumberOfCylinders { get; set; }

        /// <summary>
        /// is Alloy Rim
        /// </summary>
        public bool? IsAlloyRim { get; set; }

        /// <summary>
        /// Chasis Number
        /// </summary>
        public string ChasisNumber { get; set; }

        /// <summary>
        /// Engine Number
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// Key Code
        /// </summary>
        public string KeyCode { get; set; }

        /// <summary>
        /// Radio Code
        /// </summary>
        public string RadioCode { get; set; }

        /// <summary>
        /// Accessories
        /// </summary>
        public string Accessories { get; set; }

        /// <summary>
        /// Top Speed
        /// </summary>
        public short? TopSpeed { get; set; }

        /// <summary>
        /// Interior Description
        /// </summary>
        public string InteriorDescription { get; set; }

        /// <summary>
        /// Front Wheel Size
        /// </summary>
        public double? FrontWheelSize { get; set; }

        /// <summary>
        /// Back Wheel Size
        /// </summary>
        public double? BackWheelSize { get; set; }


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
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        #endregion
    }
}
