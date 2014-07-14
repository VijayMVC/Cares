using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Legal Status Domain Model
    /// </summary>
    public class BusinessLegalStatus
    {
        #region Persisted Properties
        /// <summary>
        /// Business Legal Status ID
        /// </summary>
        public int BusinessLegalStatusId { get; set; }
        /// <summary>
        /// Business Legal Status Code
        /// </summary>
        [StringLength(100)]
        public string BusinessLegalStatusCode { get; set; }
        /// <summary>
        /// Business Legal Status Name
        /// </summary>
        [StringLength(255)]
        public string BusinessLegalStatusName { get; set; }
        /// <summary>
        /// Business Legal Status Description
        /// </summary>
        [StringLength(500)]
        public string BusinessLegalStatusDescription { get; set; }
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
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion
    }
}
