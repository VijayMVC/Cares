using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Category Domain Model
    /// </summary>
    public class VehicleCategory
    {
        #region Persisted Properties
        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Vehicle Category Code
        /// </summary>
        [StringLength(100), Required]
        public string VehicleCategoryCode { get; set; }
        /// <summary>
        /// Vehicle Category Name
        /// </summary>
        [StringLength(255)]
        public string VehicleCategoryName { get; set; }
        /// <summary>
        /// Vehicle Category Description
        /// </summary>
        [StringLength(500)]
        public string VehicleCategoryDescription { get; set; }
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
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Hire Group Details having this Category
        /// </summary>
        public virtual ICollection<HireGroupDetail> HireGroupDetails { get; set; }

        /// <summary>
        /// Vehicles having this Vehicle Category
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        #endregion
    }
}
