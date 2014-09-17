using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Standard Rate Domain Model
    /// </summary>
    public class StandardRate
    {
        #region Perssisted Properties
        
        /// <summary>
        /// Standard Rate ID
        /// </summary>
        public long StandardRtId { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Standard Rate Main ID
        /// </summary>
        public long StandardRtMainId { get; set; }
        /// <summary>
        /// Allowed Mileage
        /// </summary>
        public int AllowedMileage { get; set; }
        /// <summary>
        /// Excess Mileage Charge
        /// </summary>
        public double ExcessMileageChrg { get; set; }
        /// <summary>
        /// Standard Rate
        /// </summary>
        public double StandardRt { get; set; }
        /// <summary>
        /// Revision Number
        /// </summary>
        public long RevisionNumber { get; set; }
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
        /// Hire Group Detail ID
        /// </summary>
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Standard Rate End Date
        /// </summary>
        public DateTime StandardRtEndDt { get; set; }
        /// <summary>
        /// Standard Rate Start Date
        /// </summary>
        public DateTime StandardRtStartDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Child Standard Rate ID
        /// </summary>
        public long? ChildStandardRtId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion
        
        #region Reference Properties
        
        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        /// <summary>
        /// Standard Rate Main
        /// </summary>
        public virtual StandardRateMain StandardRtMain { get; set; }

        /// <summary>
        /// Child Standard Rate
        /// </summary>
        public virtual StandardRate ChildStandardRate { get; set; }

        #endregion
    }
}
