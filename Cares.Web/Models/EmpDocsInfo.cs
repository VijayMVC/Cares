using System;

namespace Cares.Web.Models
{

    /// <summary>
    /// Employee Documents Info Web Model
    /// </summary>
    public class EmpDocsInfo
    {
        /// <summary>
        /// Employee Docs Info Id
        /// </summary>
        public long EmpDocsInfoId { get; set; }

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
        public long LicenseTypeId { get; set; }

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
    }
}