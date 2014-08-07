using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Country Domain Model
    /// </summary>
    public class Country
    {
        #region Persisted Properties
        
        /// <summary>
        /// Country ID
        /// </summary>
        public short CountryId { get; set; }
        
        /// <summary>
        /// Country Code
        /// </summary>
        [StringLength(100), Required]
        public string CountryCode { get; set; }
        
        /// <summary>
        /// Country Name
        /// </summary>
        [StringLength(255)]
        public string CountryName { get; set; }
        
        /// <summary>
        /// Country Description
        /// </summary>
        [StringLength(500)]
        public string CountryDescription { get; set; }
        
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
        /// Regions in the country
        /// </summary>
        public virtual ICollection<Region> Regions { get; set; } 

        #endregion
    }
}
