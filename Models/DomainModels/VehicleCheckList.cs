using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Check List Domain Model
    /// </summary>
    public sealed class VehicleCheckList
    {
        #region Persisted Properties

        /// <summary>
        ///Vehicle Check List Id
        /// </summary>
        public short VehicleCheckListId { get; set; }

        /// <summary>
        /// Vehicle Check List Code
        /// </summary>
        [StringLength(100), Required]
        public string VehicleCheckListCode { get; set; }

        /// <summary>
        /// Vehicle Check List Name
        /// </summary>
        [StringLength(255)]
        public string VehicleCheckListName { get; set; }

        /// <summary>
        /// Vehicle Check List Description
        /// </summary>
        [StringLength(500)]
        public string VehicleCheckListDescription { get; set; }

        /// <summary>
        /// Is Interior
        /// </summary>
        [Required]
        public bool IsInterior { get; set; }

        /// <summary>
        /// Vehicle Check List Key
        /// </summary>
        [Required]
        public short VehicleCheckListKey { get; set; }

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
        /// Row Vesion
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }

        #endregion
    }
}
