using System;
using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Standard Rate Main Web Models with Selected hire groups
    /// </summary>
    public class StandardRateMain
    {
        #region Public Properties
        /// <summary>
        /// Standard Rt Main Id
        /// </summary>
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// Standard Rate Main Code
        /// </summary>
        public string StandardRtMainCode { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }
        /// <summary>
        ///Standard Rate Main Name
        /// </summary>
        public string StandardRtMainName { get; set; }
        /// <summary>
        /// Standard Rate Main Description
        /// </summary>
        public string StandardRtMainDescription { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }
        /// <summary>
        /// Tariff Type ID
        /// </summary>
        public long TariffTypeId { get; set; }
        /// <summary>
        /// List of selected hire group detail for Add/Edit
        /// </summary>
        public List<StandardRate> HireGroupDetailsInStandardRtMain { get; set; }
        #endregion
    }
}