using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Document Info Domain Model
    /// </summary>
    public class EmpDocsInfo
    {
        #region Persisted Properties

        /// <summary>
        /// Employee ID
        /// </summary>
        [Key, ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        /// <summary>
        /// NIC
        /// </summary>
        [StringLength(100)]
        public string NIC { get; set; }

        /// <summary>
        /// NIC Expiry Date
        /// </summary>
        public DateTime? NICExpDt { get; set; }

        /// <summary>
        /// Iqama Number
        /// </summary>
        [StringLength(100)]
        public string IqamaNo { get; set; }

        /// <summary>
        /// Iqama Expiry Date
        /// </summary>
        public DateTime? IqamaExpDt { get; set; }

        /// <summary>
        /// Passport Number
        /// </summary>
        [StringLength(100)]
        public string PassportNo { get; set; }

        /// <summary>
        /// Passport Exp Dt
        /// </summary>
        public DateTime? PassportExpDt { get; set; }

        /// <summary>
        /// Passport Country ID
        /// </summary>
        public short? PassportCountryId { get; set; }

        /// <summary>
        /// Visa Number
        /// </summary>
        [StringLength(100)]
        public string VisaNo { get; set; }

        /// <summary>
        /// Visa Expiry Date
        /// </summary>
        public DateTime? VisaExpDt { get; set; }

        /// <summary>
        /// VisaIssue Country ID
        /// </summary>
        public short? VisaIssueCountryId { get; set; }

        /// <summary>
        /// License Number
        /// </summary>
        [StringLength(100)]
        public string LicenseNo { get; set; }

        /// <summary>
        /// License Expiry Date
        /// </summary>
        public DateTime? LicenseExpDt { get; set; }

        /// <summary>
        /// License Type ID
        /// </summary>
        [ForeignKey("LicenseType")]
        public long? LicenseTypeId { get; set; }

        /// <summary>
        /// Insurance Number
        /// </summary>
        [StringLength(100)]
        public string InsuranceNo { get; set; }

        /// <summary>
        /// Insurance Company
        /// </summary>
        [StringLength(100)]
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Insurance Date
        /// </summary>
        public DateTime? InsuranceDt { get; set; }

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

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// License Type
        /// </summary>
        public virtual LicenseType LicenseType { get; set; }


        #endregion
    }
}
