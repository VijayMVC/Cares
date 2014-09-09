using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Work Location Domain Model
    /// </summary>
    public class WorkLocation
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Location Id
        /// </summary>
        public long WorkLocationId { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        /// <summary>
        /// Work Location Code
        /// </summary>
        [StringLength(100), Required]
        public string WorkLocationCode { get; set; }

        /// <summary>
        /// Work Location Name
        /// </summary>
        [StringLength(255)]
        public string WorkLocationName { get; set; }

        /// <summary>
        /// Work Location Description
        /// </summary>
        [StringLength(500)]
        public string WorkLocationDescription { get; set; }

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
        /// Address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Phones this Work Location Has
        /// </summary>
        public virtual ICollection<Phone> Phones { get; set; }

        /// <summary>
        /// Work Places this Work Location Has
        /// </summary>
        public virtual ICollection<WorkPlace> WorkPlaces { get; set; }

        #endregion
    }
}
