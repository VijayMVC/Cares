using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Domain Model for Business Partner Company
    /// </summary>
    public class BusinessPartnerCompany
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Business Partner Company Code
        /// </summary>
        public string BusinessPartnerCompanyCode { get; set; }

        /// <summary>
        /// Business Partner Company Name
        /// </summary>
        public string BusinessPartnerCompanyName { get; set; }

        /// <summary>
        /// Established Since
        /// </summary>
        public DateTime? EstablishedSince { get; set; }

        /// <summary>
        /// Business Partner Company Swift Code
        /// </summary>
        public string SwiftCode { get; set; }

        /// <summary>
        /// Business Partner Company Account Number
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Business Segment ID
        /// </summary>
        public short? BusinessSegmentId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

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
        /// Business Segment
        /// </summary>
        public virtual BusinessSegment BusinessSegment { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
