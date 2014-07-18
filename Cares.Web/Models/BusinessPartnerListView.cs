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
        /// Business Partner List Id
        /// </summary>
        public string BusinessPartnerListId { get; set; }
        /// <summary>
        /// Business Partner List view Name
        /// </summary>
        public string BusinessPartnerListName { get; set; }
        /// <summary>
        /// Business Partner Name
        /// </summary>
        public string BusinessPartnerName { get; set; }
        /// <summary>
        /// Individual Check
        /// </summary>
        public string IsIndividual { get; set; }
        /// <summary>
        /// Business Partner Rating Type Name
        /// </summary>
        public string BPRatingTypeName { get; set; }
        /// <summary>
        /// Compnay Name
        /// </summary>
        public string CompanyName { get; set; }

        #endregion
    }
}