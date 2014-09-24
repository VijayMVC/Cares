using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Ra StatusLog Log Model
    /// </summary>
    public class RaStatusLog
    {
        #region Persisted Properties
        
        /// <summary>
        /// Ra StatusLog ID
        /// </summary>
        public long RaStatusLogId { get; set; }
        
        /// <summary>
        /// Ra StatusLog Description
        /// </summary>
        public string RaStatusDescription { get; set; }

        /// <summary>
        /// Ra Main Key
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Ra New StatusId
        /// </summary>
        public short RaNewStatusId { get; set; }

        /// <summary>
        /// Ra OldStatusId
        /// </summary>
        public short RaOldStatusId { get; set; }
        
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
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        /// <summary>
        /// New RA Status
        /// </summary>
        public virtual RaStatus RaNewStatus { get; set; }

        /// <summary>
        /// Old RA Status
        /// </summary>
        public virtual RaStatus RaOldStatus { get; set; }

        #endregion
    }
}
