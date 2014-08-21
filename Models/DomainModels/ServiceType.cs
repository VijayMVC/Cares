using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Type Domain Model
    /// </summary>
    public class ServiceType
    {
        #region Persisted Properties

        /// <summary>
        ///Service Type Id
        /// </summary>
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        [StringLength(100), Required]
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        [StringLength(255)]
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Service Type Description
        /// </summary>
        [StringLength(500)]
        public string ServiceTypeDescription { get; set; }

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
