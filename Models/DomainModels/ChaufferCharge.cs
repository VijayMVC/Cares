using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Chauffer Charge Model
    /// </summary>
    public class ChaufferCharge
    {
        #region Persisted Properties
        
        /// <summary>
        /// Chauffer Charge ID
        /// </summary>
        public long ChaufferChargeId { get; set; }

        /// <summary>
        /// Child Chauffer Charge ID
        /// </summary>
        public long? ChildChaufferChargeId { get; set; }

        /// <summary>
        /// Chauffer Charge Main ID
        /// </summary>
        public long ChaufferChargeMainId { get; set; }

        /// <summary>
        /// Desig Grade ID
        /// </summary>
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Chauffer Charge Rate
        /// </summary>
        public double ChaufferChargeRate { get; set; }
        
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }

        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
        
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
        /// Child Chauffer Charge
        /// </summary>
        public virtual ChaufferCharge ChildChaufferCharge { get; set; }

        /// <summary>
        /// Chauffer Charge Main
        /// </summary>
        public virtual ChaufferChargeMain ChaufferChargeMain { get; set; }

        /// <summary>
        /// Desig Grade
        /// </summary>
        public virtual DesignGrade DesigGrade { get; set; }

        #endregion
    }
}
