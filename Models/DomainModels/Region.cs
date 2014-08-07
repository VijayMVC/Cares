using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    public class Region
    {
        #region Persisted Properties
        /// <summary>
        /// Region ID
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// Region Code
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        [StringLength(255)]
        public string RegionName { get; set; }
        /// <summary>
        /// Region Description
        /// </summary>
        [StringLength(500)]
        public string RegionDescription { get; set; }
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

        #region Reference Properties

        /// <summary>
        /// Country
        /// </summary>
        public virtual Country Country { get; set; }

        #endregion
    }
}
