using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Standard Rate Main Domain Model
    /// </summary>
    public class StandardRateMain
    {
        #region Persisted Properties
        /// <summary>
        /// Standard Rate Main ID
        /// </summary>
        [Key]
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Standard Rate Main Code
        /// </summary>
        [StringLength(100), Required]
        public string StandardRtMainCode { get; set; }
        /// <summary>
        /// Tariff Type Code
        /// </summary>
        [StringLength(100), Required]
        public string TariffTypeCode { get; set; }
        /// <summary>
        ///Standard Rate Main Name
        /// </summary>
        [StringLength(255)]
        public string StandardRtMainName { get; set; }
        /// <summary>
        /// Standard Rate Main Description
        /// </summary>
        [StringLength(500)]
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
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Standard Rates assocaited to this Entity
        /// </summary>
        public virtual ICollection<StandardRate> StandardRates { get; set; }

        #endregion
    }
}
