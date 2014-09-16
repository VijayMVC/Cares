using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Maintenance Type Group Domain Model
    /// </summary>
    public sealed class MaintenanceTypeGroup
    {
        #region Persisted Properties

        /// <summary>
        ///Maintenance Type Group Id
        /// </summary>
        public short MaintenanceTypeGroupId { get; set; }

        /// <summary>
        /// Maintenance Type Group Code
        /// </summary>
        [StringLength(100), Required]
        public string MaintenanceTypeGroupCode { get; set; }

        /// <summary>
        /// Maintenance Type Group Name
        /// </summary>
        [StringLength(255)]
        public string MaintenanceTypeGroupName { get; set; }

        /// <summary>
        ///Maintenance Type Group Description
        /// </summary>
        [StringLength(500)]
        public string MaintenanceTypeGroupDescription { get; set; }

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
    }
}
