using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Operations Work Place Domain Model
    /// </summary>
    public class OperationsWorkPlace
    {
        #region Persisted Properties
        
        /// <summary>
        /// Operations Work Place Id
        /// </summary>
        public long OperationsWorkPlaceId { get; set; }

        /// <summary>
        /// Location Code
        /// </summary>
        [StringLength(100)]
        public string LocationCode { get; set; }

        /// <summary>
        /// Work Place Id
        /// </summary>
        [ForeignKey("WorkPlace")]
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Operation Id
        /// </summary>
        [ForeignKey("Operation")]
        public long OperationId { get; set; }

        /// <summary>
        /// Fleet Pool Id
        /// </summary>
        [ForeignKey("FleetPool")]
        public long? FleetPoolId { get; set; }



        /// <summary>
        /// CostCenter
        /// </summary>
        public int CostCenter { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Work Place
        /// </summary>
        public virtual WorkPlace WorkPlace { get; set; }

        /// <summary>
        /// Fleet Pool
        /// </summary>
        public virtual FleetPool FleetPool { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Vehicles Associated with this OperationsWorkPlace
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        #endregion
    }
}
