using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Parnter In Type Domain Model
    /// </summary>
    public class BusinessPartnerInType
    {
        #region Public Properties
        /// <summary>
        /// Business Partner In Type Id
        /// </summary>
        public long? BusinessPartnerInTypeId { get; set; }
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
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Sub Type Id
        /// </summary>
        public int BusinessPartnerSubTypeId { get; set; }
        /// <summary>
        /// Business Partner Sub Type Name
        /// </summary>
        public string BusinessPartnerSubTypeName { get; set; }
        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
        public short? BpRatingTypeId { get; set; }
        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        public string BpRatingTypeName { get; set; }
          
        #endregion

    }
}
