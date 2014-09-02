using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Other Detail Domain Model
    /// </summary>
    public class VehicleOtherDetail
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle Other Detail
        /// </summary>
        public long VehicleOtherDetailId { get; set; }

        /// <summary>
        /// Vehicle ID
        /// </summary>
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        /// <summary>
        /// Number Of Doors
        /// </summary>
        public short NumberOfDoors { get; set; }

        /// <summary>
        /// Horse Power_CC
        /// </summary>
        [Required]
        public short HorsePower_CC { get; set; }

        /// <summary>
        /// Number Of Cylinders
        /// </summary>
        public short NumberOfCylinders { get; set; }

        /// <summary>
        /// is Alloy Rim
        /// </summary>
        public bool isAlloyRim { get; set; }

        /// <summary>
        /// Chasis Number
        /// </summary>
        [StringLength(50), Required]
        public string ChasisNumber { get; set; }

        /// <summary>
        /// Engine Number
        /// </summary>
        [StringLength(50)]
        public string EngineNumber { get; set; }

        /// <summary>
        /// Key Code
        /// </summary>
        [StringLength(50)]
        public string KeyCode { get; set; }

        /// <summary>
        /// Radio Code
        /// </summary>
        [StringLength(50)]
        public string RadioCode { get; set; }

        /// <summary>
        /// Accessories
        /// </summary>
        [StringLength(500)]
        public string Accessories { get; set; }

        /// <summary>
        /// Top Speed
        /// </summary>
        public short TopSpeed { get; set; }

        /// <summary>
        /// Interior Description
        /// </summary>
        [StringLength(500)]
        public string InteriorDescription { get; set; }

        /// <summary>
        /// Front Wheel Size
        /// </summary>
        public float FrontWheelSize { get; set; }

        /// <summary>
        /// Back Wheel Size
        /// </summary>
        public float BackWheelSize { get; set; }


        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is ReadOnly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
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
