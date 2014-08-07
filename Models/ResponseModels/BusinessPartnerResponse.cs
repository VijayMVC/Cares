﻿using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Business Partner Response
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
