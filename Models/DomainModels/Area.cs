using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Area Domain Model
    /// </summary>
    public class Area
    {
        #region Persisted Properties
        /// <summary>
        /// Area ID
        /// </summary>
        public short AreaId { get; set; }
        /// <summary>
        /// Area Code
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// Area Name
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// Area Description
        /// </summary>
        public string AreaDescription { get; set; }
        /// <summary>
        /// City ID
        /// </summary>
        public short CityId { get; set; }
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
        /// City
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        #endregion
    }
}
