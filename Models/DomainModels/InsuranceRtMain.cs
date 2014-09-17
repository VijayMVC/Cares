using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Insurance Rate Main Domain Model
    /// </summary>
    public class InsuranceRtMain
    {
        #region Persisted Properties

        /// <summary>
        ///Insurance Rate Main Id
        /// </summary>
        public long InsuranceRtMainId { get; set; }

        /// <summary>
        /// Tariff type Code
        /// </summary>
        public string TariffTypeCode { get; set; }
        /// <summary>
        /// Insurance Rate Main Code
        /// </summary>
        public string InsuranceRtMainCode { get; set; }

        /// <summary>
        /// Insurance Rate Main Name
        /// </summary>
        public string InsuranceRtMainName { get; set; }

        /// <summary>
        /// Insurance Rate Main Description
        /// </summary>
        public string InsuranceRtMainDescription { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

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

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Standard Rates assocaited to this Entity
        /// </summary>
        public virtual ICollection<InsuranceRt> InsuranceRates { get; set; }

        #endregion
    }
}
