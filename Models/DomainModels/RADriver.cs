using System;

namespace Cares.Models.DomainModels
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
        /// Chauffer
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Desig Grade
        /// </summary>
        public virtual DesignGrade DesigGrade { get; set; }

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        #endregion
    }
}
