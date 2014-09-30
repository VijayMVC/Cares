using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Domain model
    /// </summary>
    public class CreditLimit
    {
        #region Persisted Properties

        /// <summary>
        /// Credit Limit ID
        /// </summary>
        public long CreditLimitId { get; set; }

        /// <summary>
        ///Credit Limit Code
        /// </summary>
        public bool IsIndividual { get; set; }

        /// <summary>
        ///Credit Limit description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Credit Limit credit limit
        /// </summary>
        public double StandardCreditLimit { get; set; }

        /// <summary>
        /// Bp Rating Type Id
        /// </summary>
        public Int16 BpRatingTypeId { get; set; }

        /// <summary>
        /// Bp Sub Type Id
        /// </summary>
        public Int16 BpSubTypeId { get; set; }

        
            
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

       
        public virtual BpRatingType BpRatingType { get; set; }

      
        public virtual BusinessPartnerSubType BpSubType { get; set; }

        #endregion
    }
}
