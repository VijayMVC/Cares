using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    public class Region
    {
        #region Persisted Properties
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
        /// <summary>
        /// Region Code
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// Region Name
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// Region Description
        /// </summary>
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

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Fleet Pools this region has
        /// </summary>
        public virtual ICollection<FleetPool> FleetPools { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Sub Regions
        /// </summary>
        public virtual ICollection<SubRegion> SubRegions { get; set; }

        #endregion
    }
}
