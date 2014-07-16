using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Api List View Model
    /// </summary> 
    public sealed class BusinessPartnerListView
    {

        #region Public Properties
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerName { get; set; }
        /// <summary>
        /// Business Partnere descritpion
        /// </summary>
        public string BusinessPartnerDesciption { get; set; }
        /// <summary>
        /// Individual Check
        /// </summary>
        public bool IsIndividual { get; set; }
        /// <summary>
        /// Business Partner Rating Type Code
        /// </summary>
        public string BPRatingTypeCode { get; set; }
        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        public string BPRatingTypeName { get; set; }
        /// <summary>
        /// Company Code
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Compnay Name
        /// </summary>
        public string CompanyName { get; set; }

        #endregion
    }
}