using System;

namespace Cares.Web.Models
{
    /// <summary>
    /// RA Driver Model
    /// </summary>
    public class RaDriver
    {
        #region Persisted Properties

        /// <summary>
        /// Ra Driver ID
        /// </summary>
        public long RaDriverId { get; set; }

        /// <summary>
        /// Chauffer ID
        /// </summary>
        public long? ChaufferId { get; set; }

        /// <summary>
        /// Ra Main ID
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Desig Grade ID
        /// </summary>
        public long? DesigGradeId { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDtTime { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDtTime { get; set; }

        /// <summary>
        /// License Exp Date
        /// </summary>
        public DateTime? LicenseExpDt { get; set; }

        /// <summary>
        /// License No
        /// </summary>
        public string LicenseNo { get; set; }

        /// <summary>
        /// Driver Name
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Is Chauffer
        /// </summary>
        public bool IsChauffer { get; set; }

        /// <summary>
        /// Tariff Type
        /// </summary>
        public string TariffType { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Total Charge
        /// </summary>
        public double TotalCharge { get; set; }

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
        
        #endregion

    }
}