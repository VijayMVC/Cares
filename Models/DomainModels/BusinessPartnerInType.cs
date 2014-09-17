using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Parnter In Type Domain Model
    /// </summary>
    public class BusinessPartnerInType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Business Partner In Type Id
        /// </summary>
        public long BusinessPartnerInTypeId { get; set; }
        
        /// <summary>
        /// Business Partner In Type Description
        /// </summary>
        public string BusinessPartnerInTypeDescription { get; set; }
        
        /// <summary>
        /// Business Partner In Type From Date
        /// </summary>
        public DateTime? FromDate { get; set; }
        
        /// <summary>
        /// Business Partner In Type To Date
        /// </summary>
        public DateTime? ToDate { get; set; }
        
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }
        
        /// <summary>
        /// Business Partner Sub Type Id
        /// </summary>
        public short BusinessPartnerSubTypeId { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
        
        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
        public short? BpRatingTypeId { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties
      
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        
        /// <summary>
        /// Business Partner Rating Type
        /// </summary>
        public virtual BpRatingType BpRatingType { get; set; }

        /// <summary>
        /// Business Partner Sub Type
        /// </summary>
        public virtual BusinessPartnerSubType BusinessPartnerSubType { get; set; }
        
        #endregion
    }
}
