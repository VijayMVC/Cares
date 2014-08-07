using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DomainModels
{
    /// <summary>
    /// Work Place Domain Model
    /// </summary>
    public class WorkPlace
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Place Id
        /// </summary>
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Work Location Id
        /// </summary>
        [ForeignKey("WorkLocation")]
        public long WorkLocationId { get; set; }

        /// <summary>
        /// Work Place Code
        /// </summary>
        [StringLength(100), Required]
        public string WorkPlaceCode { get; set; }

        /// <summary>
        /// Work Place Name
        /// </summary>
        [StringLength(255)]
        public string WorkPlaceName { get; set; }

        /// <summary>
        /// Work Place Description
        /// </summary>
        [StringLength(500)]
        public string WorkPlaceDescription { get; set; }

        /// <summary>
        /// Parent Work Place Id
        /// </summary>
        [ForeignKey("ParentWorkPlace")]
        public long? ParentWorkPlaceId { get; set; }

        /// <summary>
        /// Work Place Type Id
        /// </summary>
        [ForeignKey("WorkPlaceType")]
        public short WorkPlaceTypeId { get; set; }

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
        public virtual WorkPlace ParentWorkPlace { get; set; }

        /// <summary>
        /// Work Place Type
        /// </summary>
        public virtual WorkPlaceType WorkPlaceType { get; set; }

        /// <summary>
        /// Work Location
        /// </summary>
        public virtual WorkLocation WorkLocation { get; set; }

        /// <summary>
        /// Operations Workplaces that use this workspace
        /// </summary>
        public virtual ICollection<OperationsWorkPlace> OperationsWorkPlaces { get; set; } 

        #endregion
    }
}
