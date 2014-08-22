using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Service Rate Main Domain Model
    /// </summary>
    public class ServiceRtMain
    {
        #region Persisted Properties

        /// <summary>
        ///Service Rate Main Id
        /// </summary>
        public long ServiceRtMainId { get; set; }

        /// <summary>
        /// Service Type Code
        /// </summary>
        [StringLength(100), Required]
        public string ServiceRtMainCode { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        [StringLength(100), Required]
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Service Type Name
        /// </summary>
        [StringLength(255)]
        public string ServiceRtMainName { get; set; }

        /// <summary>
        /// Service Type Description
        /// </summary>
        [StringLength(500)]
        public string ServiceRtMainDescription { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [Required]
        public DateTime StartDt { get; set; }

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
        /// Service Rates assocaited to this Entity
        /// </summary>
        public virtual ICollection<ServiceRt> ServiceRts { get; set; }

        #endregion
    }
}
