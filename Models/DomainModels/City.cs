using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// City Domain Model
    /// </summary>
    public class City
    {
        #region Persisted Properties
        /// <summary>
        /// City ID
        /// </summary>
        public short CityId { get; set; }
        /// <summary>
        /// City Code
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// City Name
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// City Description
        /// </summary>
        public string CityDescription { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public short? RegionId { get; set; }
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short? SubRegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
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
        /// Region
        /// </summary>
        public virtual Region Region { get; set; }
        /// <summary>
        /// Sub Region
        /// </summary>
        public virtual SubRegion SubRegion { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Areas
        /// </summary>
        public virtual ICollection<Area> Areas { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        #endregion
    }
}
