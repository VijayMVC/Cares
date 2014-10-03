using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Insurance Rate
    /// </summary>
    public class InsuranceRt
    {
        #region Persisted Properties

        /// <summary>
        /// Insurance Rate ID
        /// </summary>
        public long InsuranceRtId { get; set; }
        /// <summary>
        ///Insurance Rate MainId
        /// </summary>
        public long InsuranceRtMainId { get; set; }
        /// <summary>
        /// Child Insurance Rate ID
        /// </summary>
        public long? ChildInsuranceRtId { get; set; }
        /// <summary>
        /// Insurance Type ID
        /// </summary>
        public short InsuranceTypeId { get; set; }
        /// <summary>
        /// Hire Group Detail ID
        /// </summary>
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Insurance Rate
        /// </summary>
        public double InsuranceRate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDt { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }
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
        /// Child Insurance Rate
        /// </summary>
        public virtual ICollection<InsuranceRt> ChildInsuranceRt { get; set; }

        /// <summary>
        /// Insurance Rate Main
        /// </summary>
        public virtual InsuranceRtMain InsuranceRtMain { get; set; }

        /// <summary>
        ///Insurance Type
        /// </summary>
        public virtual InsuranceType InsuranceType { get; set; }

        /// <summary>
        /// Hire Group Detail
        /// </summary>
        public virtual HireGroupDetail HireGroupDetail { get; set; }

        #endregion
    }
}
