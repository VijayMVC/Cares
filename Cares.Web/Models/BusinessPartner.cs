using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Api Model
    /// </summary>
    public sealed class BusinessPartner
    {
        #region Public Properties
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Code
        /// </summary>
        public string BusinessPartnerCode { get; set; }
        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerName { get; set; }
        /// <summary>
        /// Business Partnere descritpion
        /// </summary>
        public string BusinessPartnerDesciption { get; set; }
        /// <summary>
        /// System Guarantor Check
        /// </summary>
        public bool IsSystemGuarantor { get; set; }
        /// <summary>
        /// System Guarantor ID
        /// </summary>
        public long SystemGuarantorId { get; set; }
        /// <summary>
        /// Non System Guarantor
        /// </summary>
        public string NonSystemGuarantor { get; set; }
        /// <summary>
        /// Individual Check
        /// </summary>
        public bool IsIndividual { get; set; }
        /// <summary>
        /// Dealing Employee Id
        /// </summary>
        public long DealingEmployeeId { get; set; }
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
        public String RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Business Partner Email Address
        /// </summary>
        public string BusinessPartnerEmailAddress { get; set; }
        /// <summary>
        /// Business Partner Is Valid
        /// </summary>
        public bool BusinessPartnerIsValid { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        #endregion
    }
}