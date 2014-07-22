﻿using System;
using Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Company Web Api Model
    /// </summary>
    public class BusinessPartnerCompany
    {
        #region Public Properties
        
        /// <summary>
        /// Business Partner Company Id
        /// </summary>
        public long BusinessPartnerCompanyId { get; set; }
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
        public DateTime EstablishedSince { get; set; }
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
        public int BusinessSegmentId { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

 
        #endregion
    }
}