using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Phone Domain Model
    /// </summary>
    public class Phone
    {
        #region Persisted Properties
        /// <summary>
        /// Phone Id
        /// </summary>
        public long PhoneId { get; set; }
        /// <summary>
        /// Is Default
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [ForeignKey("BusinessPartner")]
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Phone Type ID
        /// </summary>
        [ForeignKey("PhoneType")]
        public int PhoneTypeId { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
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
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference properties
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        /// <summary>
        /// Phone Type
        /// </summary>
        public virtual PhoneType PhoneType { get; set; }
        #endregion
    }
}
