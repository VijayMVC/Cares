using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Country Domain Model
    /// </summary>
    public class Country
    {
        #region Persisted Properties
        /// <summary>
        /// Country ID
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// Country Code
        /// </summary>
        [StringLength(100)]
        public string CountryCode { get; set; }
        /// <summary>
        /// Country Name
        /// </summary>
        [StringLength(255)]
        public string CountryName { get; set; }
        /// <summary>
        /// Country Description
        /// </summary>
        [StringLength(255)]
        public string CountryDescription { get; set; }
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
