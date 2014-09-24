using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// RA HireGroup Insurance Model
    /// </summary>
    public class RaHireGroupInsurance
    {
        #region Persisted Properties
        
        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaHireGroupInsuranceId { get; set; }

        /// <summary>
        /// Ra HireGroup Insurance Description
        /// </summary>
        public string RaHireGroupInsuranceDescription { get; set; }

        /// <summary>
        /// RA Hire Group Id
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Insurance Type Id
        /// </summary>
        public short InsuranceTypeId { get; set; }

        /// <summary>
        /// Start Datetime
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Datetime
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// Insurance Rate
        /// </summary>
        public double InsuranceRate { get; set; }

        /// <summary>
        /// Insurance Charge
        /// </summary>
        public double InsuranceCharge { get; set; }

        /// <summary>
        /// Charged Day
        /// </summary>
        public int ChargedDay { get; set; }

        /// <summary>
        /// Charged Hour
        /// </summary>
        public int ChargedHour { get; set; }

        /// <summary>
        /// Charged Minute
        /// </summary>
        public int ChargedMinute { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffType { get; set; }
        
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
        /// Ra Hire Group
        /// </summary>
        public virtual RaHireGroup RaHireGroup { get; set; }

        /// <summary>
        /// Insurance Type
        /// </summary>
        public virtual InsuranceType InsuranceType { get; set; }
        
        #endregion
    }
}
