using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Chauffer Charge Main Model
    /// </summary>
    public class ChaufferChargeMain
    {
        #region Persisted Properties
        
        /// <summary>
        /// Chauffer Charge Main ID
        /// </summary>
        public long ChaufferChargeMainId { get; set; }

        /// <summary>
        /// Chauffer Charge Main Code
        /// </summary>
        public string ChaufferChargeMainCode { get; set; }

        /// <summary>
        /// Tariff Type Code
        /// </summary>
        public string TariffTypeCode { get; set; }

        /// <summary>
        /// Chauffer Charge Main Name
        /// </summary>
        public string ChaufferChargeMainName { get; set; }

        /// <summary>
        /// Chauffer Charge Main Description
        /// </summary>
        public string ChaufferChargeMainDescription { get; set; }

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
        /// Chauffer Charges
        /// </summary>
        public virtual ICollection<ChaufferCharge> ChaufferCharges { get; set; }

        #endregion
    }
}
