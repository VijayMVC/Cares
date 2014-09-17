using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Partner Rating Type Domain Model
    /// </summary>
    public class BpRatingType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Business Partner Rating Type ID
        /// </summary>
        public short BpRatingTypeId { get; set; }

        /// <summary>
        /// Business Partner Rating Type Code
        /// </summary>
        public string BpRatingTypeCode { get; set; }

        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        public string BpRatingTypeName { get; set; }

        /// <summary>
        /// Business Partner Rating Type Description
        /// </summary>
        public string BpRatingTypeDescription { get; set; }

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
        /// Business Partner InType Assocaited to this Rating Type
        /// </summary>
        public virtual ICollection<BusinessPartnerInType> BusinessPartnerInTypes { get; set; }

        /// <summary>
        /// Business Partners Assocaited to this Rating Type
        /// </summary>
        public virtual ICollection<BusinessPartner> BusinessPartners { get; set; }

        #endregion
    }
}
