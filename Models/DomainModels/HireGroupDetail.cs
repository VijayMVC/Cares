using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Detail Domain Model
    /// </summary>
    public class HireGroupDetail
    {
        #region Persisted Properties
        
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Hire Group ID
        /// </summary>
        [ForeignKey("HireGroup")]
        public long HireGroupId { get; set; }
        
        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        [ForeignKey("VehicleCategory")]
        public short VehicleCategoryId { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        [ForeignKey("VehicleModel")]
        public short VehicleModelId { get; set; }
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        [ForeignKey("VehicleMake")]
        public short VehicleMakeId { get; set; }
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
        /// Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }
        /// <summary>
        /// Vehicle Category
        /// </summary>
        public virtual VehicleCategory VehicleCategory { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public virtual VehicleMake VehicleMake { get; set; }
        /// <summary>
        /// Vehicle Model
        /// </summary>
        public virtual VehicleModel VehicleModel { get; set; }
        ///// <summary>
        ///// Stanadard Rate 
        ///// </summary>
        //public virtual ICollection<StandardRate> StandardRate { get; set; }
        #endregion
    }
}
