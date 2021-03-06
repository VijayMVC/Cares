﻿using System;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Service Rate Main Domain Content
    /// </summary>
    public sealed class ServiceRtMainContent
    {
        /// <summary>
        /// Service Rate Main ID
        /// </summary>
        public long ServiceRtMainId { get; set; }
        /// <summary>
        /// Service Rate Main Code
        /// </summary>
        public string ServiceRtMainCode { get; set; }
        /// <summary>
        ///Service Rate Main Name
        /// </summary>
        public string ServiceRtMainName { get; set; }
        /// <summary>
        /// Service Rate Main Description
        /// </summary>
        public string ServiceRtMainDescription { get; set; }

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
    }
}
