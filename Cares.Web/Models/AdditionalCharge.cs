﻿using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Additional Charge Web Model
    /// </summary>
    public class AdditionalCharge
    {
        /// <summary>
        /// Additional Charge ID
        /// </summary>
        public long AdditionalChargeId { get; set; }

        /// <summary>
        /// Child Additional Charge ID
        /// </summary>
        public long? ChildAdditionalChargeId { get; set; }

        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long? HireGroupDetailId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long? RevisionNumber { get; set; }

        /// <summary>
        /// Additional Charge Rate
        /// </summary>
        public double? AdditionalChargeRate { get; set; }

        /// <summary>
        /// Hire group Detail Code Name
        /// </summary>
        public string HireGroupDetailCodeName { get; set; }
    }
}