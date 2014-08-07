using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Tariff Rate Contents to be displaye on the list of Standard Rates
    /// </summary>
    public sealed class TariffRateContent
    {
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// Standard Rate Main Code
        /// </summary>
        public string StandardRtMainCode { get; set; }
        /// <summary>
        ///Standard Rate Main Name
        /// </summary>
        public string StandardRtMainName { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCodeName { get; set; }        
        /// <summary>
        /// Standard Rate Main Description
        /// </summary>
        public string StandardRtMainDescription { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }
        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDt { get; set; }
        /// <summary>
        /// Operation Id
        /// </summary>
        public long OperationId { get; set; }
        /// <summary>
        /// Tariff Type ID
        /// </summary>
        public long TariffTypeId { get; set; }

        /// <summary>
        /// Operation Code Name
        /// </summary>
        public string OperationCodeName { get; set; }
    }
}
