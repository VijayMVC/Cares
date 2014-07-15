using System;
using Cares.Web.Models;

namespace Cares.Web.Models
{
    /// <summary>
    /// FleetPool Model
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
        public string FleetPoolCode { get; set; }
        /// <summary>
        /// FleetPool Name
        /// </summary>
        public string FleetPoolName { get; set; }
        /// <summary>
        /// FleetPool Description
        /// </summary>
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
        public long OperationId { get; set; }
        /// <summary>
        /// Region ID
        /// </summary>
        public short RegionId { get; set; }
        /// <summary>
        /// FleetPool Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// FleetPool Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// FleetPool Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// FleetPool Last Updated By
        /// </summary>
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
        public  Operation Operation { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public  Region Region { get; set; }
        #endregion
    }
}