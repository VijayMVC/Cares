using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Sub Status Domain Model
    /// </summary>
    public class VehicleSubStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Sub Status ID
        /// </summary>
        public short VehicleSubStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Id
        /// </summary>
        [ForeignKey("VehicleStatus")]
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Sub Status Code
        /// </summary>
        [StringLength(100), Required]
        public string VehicleSubStatusCode { get; set; }

        /// <summary>
        /// Vehicle Sub Status Name
        /// </summary>
        [StringLength(255)]
        public string VehicleSubStatusName { get; set; }

        /// <summary>
        /// Vehicle Sub Status Description
        /// </summary>
        [StringLength(500)]
        public string VehicleSubStatusDescription { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

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
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public virtual VehicleStatus VehicleStatus { get; set; }

        #endregion
    }
}
