using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Work Place Type Domain Model
    /// </summary>
    public class WorkPlaceType
    {
        #region Persisted Properties
        
        /// <summary>
        /// Work Place Type Id
        /// </summary>
        public short WorkPlaceTypeId { get; set; }
        
        /// <summary>
        /// WorkPlace Type Code
        /// </summary>
        [StringLength(100), Required]
        public string WorkPlaceTypeCode { get; set; }

        /// <summary>
        /// WorkPlace Type Name
        /// </summary>
        [StringLength(255)]
        public string WorkPlaceTypeName { get; set; }

        /// <summary>
        /// WorkPlace Type Description
        /// </summary>
        [StringLength(500)]
        public string WorkPlaceTypeDescription { get; set; }

        /// <summary>
        /// Work Place Type Cat
        /// </summary>
        public short WorkPlaceTypeCat { get; set; }

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
        /// WorkPlaces having this Workplace Type
        /// </summary>
        public virtual ICollection<WorkPlace> WorkPlaces { get; set; }

        #endregion

    }
}
