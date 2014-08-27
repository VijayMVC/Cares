using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Maintenance Type Domain Model
    /// </summary>
    public class MaintenanceType
    {
        #region Persisted Properties

        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeId { get; set; }

        /// <summary>
        /// Maintenance Type Group Id
        /// </summary>
        [ForeignKey("MaintenanceTypeGroup")]
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Code
        /// </summary>
        [StringLength(100), Required]
        public string MaintenanceTypeCode { get; set; }

        /// <summary>
        /// Maintenance Type Name
        /// </summary>
        [StringLength(255)]
        public string MaintenanceTypeName { get; set; }

        /// <summary>
        ///Maintenance Type Description
        /// </summary>
        [StringLength(500)]
        public string MaintenanceTypeDescription { get; set; }

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
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

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
        /// Row Vesion
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
        /// Maintenance Type Group
        /// </summary>
        public virtual MaintenanceTypeGroup MaintenanceTypeGroup { get; set; }

        #endregion
    }
}
