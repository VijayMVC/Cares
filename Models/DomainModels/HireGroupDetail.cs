using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Hire Group Detail Domain Model
    /// </summary>
    public class HireGroupDetail
    {
        #region Persisted Properties
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        [Key]
        public long HireGroupDetailId { get; set; }
        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long HireGroupId { get; set; }
        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short VehicleModelId { get; set; }
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
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
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion
    }
}
