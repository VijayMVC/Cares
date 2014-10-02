using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cares.Web.Models
{
    /// <summary>
    /// Business Partner Sub Type Base Data Response Web Model
    /// </summary>
    public class BusinessPartnerSubTypeBaseDataResponse
    {
        #region Public
        /// <summary>
        /// Business Partner Main Types
        /// </summary>
        public IEnumerable<BusinessPartnerMainTypeDropDown> BusinessPartnerMainTypeDropDown { get; set; }
        #endregion
    }
}