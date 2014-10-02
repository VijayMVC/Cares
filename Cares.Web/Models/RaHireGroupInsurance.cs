using System;

namespace Cares.Web.Models
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
        /// RA Hire Group Id
        /// </summary>
        public long RaHireGroupId { get; set; }

        /// <summary>
        /// Insurance Type Id
        /// </summary>
        public short InsuranceTypeId { get; set; }

        /// <summary>
        /// Insurance Type Code
        /// </summary>
        public string InsuranceTypeCodeName { get; set; }
        
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
        
        #endregion

    }
}