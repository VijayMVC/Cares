using System;

namespace Cares.Models.DomainModels
{
    public class BusinessPartnerDocument
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner ID
        /// </summary>
        public long BusinessPartnerDocumentId { get; set; }

        /// <summary>
        /// Business Partner Code
        /// </summary>
        public string BusinessPartnerDocumentCode { get; set; }

        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerDocumentName { get; set; }

        /// <summary>
        /// Business Partner Description
        /// </summary>
        public string BusinessPartnerDocumentDescription { get; set; }

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
        public string UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }
        public int DocumentId { get; set; }
        public byte[] Document { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public long BusinessPartnerId { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partner Associated to this
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        /// <summary>
        /// Business Partner Document Associated to this
        /// </summary>
        public virtual Document BpDocument { get; set; }

        #endregion
    }
}
