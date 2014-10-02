
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Business Partner Sub Type Base Data Response domain model
    /// </summary>
    public class BusinessPartnerSubTypeBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Business Partner Main Types
        /// </summary>
        public IEnumerable<BusinessPartnerMainType> BusinessPartnerMainType { get; set; }
        #endregion
    }
}
