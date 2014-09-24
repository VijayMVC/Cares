using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Nrt Driver Model
    /// </summary>
    public class NrtDriver
    {
        #region Persisted Properties
        
        /// <summary>
        /// Nrt Driver ID
        /// </summary>
        public long NrtDriverId { get; set; }

        /// <summary>
        /// Chauffer ID
        /// </summary>
        public long? ChaufferId { get; set; }

        /// <summary>
        /// Nrt Vehicle ID
        /// </summary>
        public long? NrtVehicleId { get; set; }

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
        /// Nrt Vehicle
        /// </summary>
        public virtual NrtVehicle NrtVehicle { get; set; }

        #endregion
    }
}
