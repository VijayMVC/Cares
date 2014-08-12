using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Image Domain Model
    /// </summary>
    public class VehicleImage
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Image ID
        /// </summary>
        public long VehicleImageId { get; set; }
        
        /// <summary>
        /// Vehicle Image Code
        /// </summary>
        [StringLength(255), Required]
        public string VehicleImageCode { get; set; }

        /// <summary>
        /// Vehicle Image Name
        /// </summary>
        [StringLength(255)]
        public string VehicleImageName { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [Required]
        public byte[] Image { get; set; }
        
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
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle Image Hire Group Details Associated to this Vehicle Image
        /// </summary>
        public virtual ICollection<VehicleImageHireGroupDetail> VehicleImageHireGroupDetails { get; set; } 

        #endregion
    }
}
