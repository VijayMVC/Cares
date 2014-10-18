using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// Payment Mode Domain Model
    /// </summary>
    public class PaymentMode
    {
        #region Public

        /// <summary>
        /// Payment Mode ID
        /// </summary>
        public short PaymentModeId { get; set; }

        /// <summary>
        /// Payment Mode Code
        /// </summary>
        public string PaymentModeCode { get; set; }

        /// <summary>
        /// Payment Mode Name
        /// </summary>
        public string PaymentModeName { get; set; }

        /// <summary>
        /// Payment Mode Code Name
        /// </summary>
        public string PaymentModeCodeName { get; set; }

        /// <summary>
        /// Payment Mode Description
        /// </summary>
        public string PaymentModeDescription { get; set; }

        /// <summary>
        /// Payment Mode Key
        /// </summary>
        public short? PaymentModeKey { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        #endregion
    }
}

