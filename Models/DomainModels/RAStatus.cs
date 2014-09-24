using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Ra Status Model
    /// </summary>
    public class RaStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Ra Status ID
        /// </summary>
        public short RaStatusId { get; set; }

        /// <summary>
        /// Ra Status Code
        /// </summary>
        public string RaStatusCode { get; set; }

        /// <summary>
        /// Ra Status Name
        /// </summary>
        public string RaStatusName { get; set; }

        /// <summary>
        /// Ra Status Description
        /// </summary>
        public string RaStatusDescription { get; set; }

        /// <summary>
        /// Ra Status Key
        /// </summary>
        public short? RaStatusKey { get; set; }

        /// <summary>
        /// Is RA
        /// </summary>
        public bool IsRa { get; set; }

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
        /// Ra Status Logs
        /// </summary>
        public virtual ICollection<RaStatusLog> NewRaStatusLogs { get; set; }

        /// <summary>
        /// Ra Status Logs
        /// </summary>
        public virtual ICollection<RaStatusLog> OldRaStatusLogs { get; set; }

        /// <summary>
        /// Nrt Mains
        /// </summary>
        public virtual ICollection<NrtMain> NrtMains { get; set; }

        /// <summary>
        /// Ra Mains
        /// </summary>
        public virtual ICollection<RaMain> RaMains { get; set; }

        #endregion
    }
}
