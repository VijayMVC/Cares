using System;
using System.ComponentModel.DataAnnotations;
namespace Models.DomainModels
{
    /// <summary>
    /// Vehicle Domain Model  
    /// </summary>
    public class VehicleModel
    {
        #region Persisted Properties
        /// <summary>
        /// Vehicle Mode ld
        /// </summary>
        [Key]
        public short VehicleModelId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        /// <summary>
        /// Vehicl eModel Code
        /// </summary>
        [StringLength(100)]
        public string VehicleModelCode { get; set; }
        /// <summary>
        /// Vehicle Model Name
        /// </summary>
        [StringLength(255)]
        public string VehicleModelName { get; set; }
        /// <summary>
        /// Vehicle Model Description
        /// </summary>
        [StringLength(500)]
        public string VehicleModelDescription { get; set; }
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
