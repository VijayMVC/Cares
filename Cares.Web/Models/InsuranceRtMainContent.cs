using System;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Insurance Rate Main web Content
    /// </summary>
    public class InsuranceRtMainContent
    {
        #region Insurance Rate Main Properties
        public long InsuranceRtMainId { get; set; }
        /// <summary>
        /// Standard Rate Main Code
        /// </summary>
        public string InsuranceRtMainCode { get; set; }
        /// <summary>
        ///Standard Rate Main Name
        /// </summary>
        public string InsuranceRtName { get; set; }
        /// <summary>
        /// Standard Rate Main Description
        /// </summary>
        public string InsuranceRtMainDescription { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCodeName { get; set; }

        /// <summary>
        /// Tariff Type ID
        /// </summary>
        public long TariffTypeId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }
        #endregion

        #region Reference Properties
        /// <summary>
        /// Insurance Rate List
        /// </summary>
        public List<InsuranceRtDetailContent> InsuranceRts { get; set; }

        #endregion
    }
}