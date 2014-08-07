using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public int ApproximateVehiclesAsgnd { get; set; }
        
        /// <summary>
        /// FleetPool Code
        /// </summary>
        [StringLength(100), Required]
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
        [Required]
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Is FleetPool Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Is FleetPool ReadOnly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }
        
        /// <summary>
        /// Is FleetPool Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Operation ID
        /// </summary>
        [ForeignKey("Operation")]
        public long OperationId { get; set; }
        
        /// <summary>
        /// Region ID
        /// </summary>
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        
        /// <summary>
        /// FleetPool Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        
        /// <summary>
        /// FleetPool Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// FleetPool Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }
        
        /// <summary>
        /// FleetPool Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// FleetPool Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }
        
        /// <summary>
        /// FleetPool User Domain Key
        /// </summary>
        [Required]
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

        /// <summary>
        /// Operations Workplaces this FleetPool has
        /// </summary>
        public virtual ICollection<OperationsWorkPlace> OperationsWorkPlaces { get; set; }
        
        #endregion
    }
}
