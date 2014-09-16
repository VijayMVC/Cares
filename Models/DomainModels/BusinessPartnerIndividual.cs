using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Parnter Individual Domain Model
    /// </summary>
    public class BusinessPartnerIndividual
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner Id
        /// </summary>
        [Key]
        [ForeignKey("BusinessPartner")]
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Individual First Name
        /// </summary>
        [StringLength(255)]
        public string FirstName { get; set; }

        /// <summary>
        /// Individual Middle Name
        /// </summary>
        [StringLength(255)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Individual Last Name
        /// </summary>
        [StringLength(255)]
        public string LastName { get; set; }

        /// <summary>
        /// Individual Initials
        /// </summary>
        [StringLength(5)]
        public string Initials { get; set; }

        /// <summary>
        /// Individual License Number
        /// </summary>
        [StringLength(100)]
        public string LiscenseNumber { get; set; }

        /// <summary>
        /// Individual License Expiry Date
        /// </summary>
        public DateTime? LiscenseExpiryDate { get; set; }

        /// <summary>
        /// Individual Gender Status
        /// </summary>
        [StringLength(1)]
        public string GenderStatus { get; set; }

        /// <summary>
        /// Individual Passport Number
        /// </summary>
        [StringLength(100)]
        public string PassportNumber { get; set; }

        /// <summary>
        /// Individual NIC Number
        /// </summary>
        [StringLength(100)]
        public string NicNumber { get; set; }

        /// <summary>
        /// Individual Marital Status Code
        /// </summary>
        [StringLength(10)]
        public string MaritalStatusCode { get; set; }

        /// <summary>
        /// Tax Registration Code
        /// </summary>
        [StringLength(100)]
        public string TaxRegisterationCode { get; set; }

        /// <summary>
        /// Tax Number
        /// </summary>
        [StringLength(100)]
        public string TaxNumber { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Individual Occupation Type Id
        /// </summary>
        [ForeignKey("OccupationType")]
        public int? OccupationTypeId { get; set; }

        /// <summary>
        /// Individual Is Company External
        /// </summary>
        [Required]
        public bool IsCompanyExternal { get; set; }

        /// <summary>
        /// Individual Company Name
        /// </summary>
        [StringLength(255)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Individual Company Address
        /// </summary>
        [StringLength(500)]
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Inidividual Company Phone
        /// </summary>
        [StringLength(25)]
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Individual Business Partner Company Id
        /// </summary>
        [ForeignKey("BusinessPartnerCompany")]
        public long? BusinessPartnerCompnayId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [Required]
        [StringLength(100)]
        public String RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Individual Nic Expiry date
        /// </summary>
        public DateTime? NicExpiryDate { get; set; }

        /// <summary>
        /// Individual Passport Expiry date
        /// </summary>
        public DateTime? PassportExpiryDate { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }

        /// <summary>
        /// Individual Passport Country Id
        /// </summary>
        [ForeignKey("PassportCountry")]
        public short? PassportCountryId { get; set; }

        /// <summary>
        /// Individual Iqama No
        /// </summary>
        [StringLength(100)]
        public String IqamaNo { get; set; }

        /// <summary>
        /// Inidividual Iqama expiry date
        /// </summary>
        public DateTime? IqamaExpiryDate { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Occupation Type
        /// </summary>
        public virtual OccupationType OccupationType { get; set; }

        /// <summary>
        /// Business Partner Company
        /// </summary>
        public virtual BusinessPartnerCompany BusinessPartnerCompany { get; set; }

        /// <summary>
        /// Passport Country
        /// </summary>
        public virtual Country PassportCountry { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }


        #endregion
    }
}
