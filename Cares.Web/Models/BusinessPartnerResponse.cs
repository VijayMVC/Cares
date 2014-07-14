﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Api Response
    /// </summary>
    public sealed class BusinessPartnerResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerResponse()
        {
            BusinessPartners = new List<BusinessPartner>();
        }

        /// <summary>
        /// Business Partners
        /// </summary>
        public IEnumerable<BusinessPartner> BusinessPartners { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}