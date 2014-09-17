using System;

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
        public long EmployeeId { get; set; }

        /// <summary>
        /// NIC
        /// </summary>
        public string NIC { get; set; }

        /// <summary>
        /// NIC Expiry Date
        /// </summary>
        public DateTime? NICExpDt { get; set; }

        /// <summary>
        /// Iqama Number
        /// </summary>
        public string IqamaNo { get; set; }

        /// <summary>
        /// Iqama Expiry Date
        /// </summary>
        public DateTime? IqamaExpDt { get; set; }

        /// <summary>
        /// Passport Number
        /// </summary>
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
        public string LicenseNo { get; set; }

        /// <summary>
        /// License Expiry Date
        /// </summary>
        public DateTime? LicenseExpDt { get; set; }

        /// <summary>
        /// License Type ID
        /// </summary>
        public long? LicenseTypeId { get; set; }

        /// <summary>
        /// Insurance Number
        /// </summary>
        public string InsuranceNo { get; set; }

        /// <summary>
        /// Insurance Company
        /// </summary>
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Insurance Date
        /// </summary>
        public DateTime? InsuranceDt { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
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
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
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
