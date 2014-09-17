using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Sub Region Domain Model
    /// </summary>
    public class SubRegion
    {
        #region Persisted Properties
        /// <summary>
        /// Sub Region ID
        /// </summary>
        public short SubRegionId { get; set; }
        /// <summary>
        /// Sub Region Code
        /// </summary>
        public string SubRegionCode { get; set; }
        /// <summary>
        /// Sub Region Name
        /// </summary>
        public string SubRegionName { get; set; }
        /// <summary>
        /// Sub Region Description
        /// </summary>
        public string SubRegionDescription { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
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
        /// Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Cities
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }


        #endregion
    }
}
