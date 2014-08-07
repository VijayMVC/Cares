using System;
using System.ComponentModel.DataAnnotations;
using Models.DomainModels;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// FleetPool Domail Model
    /// </summary>
    public class FleetPool
    {
        #region FleetPool Persisted Properties
        /// <summary>
        /// FleetPool ID
        /// </summary>
        public long FleetPoolId { get; set; }
        /// <summary>
        /// Approximate Vehicles Assigned
        /// </summary>
        public int ApproximateVehiclesAsgnd { get; set; }
        /// <summary>
        /// FleetPool Code
        /// </summary>
        [StringLength(100)]
        public string FleetPoolCode { get; set; }
        /// <summary>
        /// FleetPool Name
        /// </summary>
        [StringLength(255)]
        public string FleetPoolName { get; set; }
        /// <summary>
        /// FleetPool Description
        /// </summary>
        [StringLength(500)]
        public string FleetPoolDescription { get; set; }
        /// <summary>
        /// Is FleetPool Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is FleetPool Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is FleetPool ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Is FleetPool Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Operation ID
        /// </summary>
        public int OperationId { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// FleetPool Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// FleetPool Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// FleetPool Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// FleetPool Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// FleetPool Row Version
        /// </summary>
        public long RowVersion { get; set; }
        /// <summary>
        /// FleetPool User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        #endregion

        #region Reference Properties
            /// <summary>
            /// Operation
            /// </summary>
            public virtual Operation Operation { get; set; }
            /// <summary>
            /// Region
            /// </summary>
            public virtual Region Region { get; set; }
        #endregion
    }
}
