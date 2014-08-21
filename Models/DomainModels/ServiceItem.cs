using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Item Domain Models
    /// </summary>
    public class ServiceItem
    {
        #region Persisted Properties

        /// <summary>
        ///Service Item Id
        /// </summary>
        public long ServiceItemId { get; set; }

        /// <summary>
        /// Service Type ID
        /// </summary>
        [ForeignKey("ServiceType")]
        public short ServiceTypeId { get; set; }

        /// <summary>
        /// Service Item Code
        /// </summary>
        [StringLength(100), Required]
        public string ServiceItemCode { get; set; }

        /// <summary>
        /// Service Item Name
        /// </summary>
        [StringLength(255)]
        public string ServiceItemName { get; set; }

        /// <summary>
        /// Service Item Description
        /// </summary>
        [StringLength(500)]
        public string ServiceItemDescription { get; set; }

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
        /// Service Type
        /// </summary>
        public virtual ServiceType ServiceType { get; set; }

        #endregion
    }
}
