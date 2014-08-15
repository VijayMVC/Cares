using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Domain Model
    /// </summary>
    public class HireGroup
    {
        #region Persisted Properties
        
        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long HireGroupId { get; set; }
        
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Parent Hire Group ID
        /// </summary>
        [ForeignKey("ParentHireGroup")]
        public long? ParentHireGroupId { get; set; }
        
        /// <summary>
        /// Company ID
        /// </summary>
        [ForeignKey("Company")]
        public long? CompanyId { get; set; }
        
        /// <summary>
        ///Hire Group Name
        /// </summary>
        [StringLength(255)]
        public string HireGroupName { get; set; }
        
        /// <summary>
        /// Hire Group Code
        /// </summary>
        [StringLength(100), Required]
        public string HireGroupCode { get; set; }

        /// <summary>
        /// Hire Group Description
        /// </summary>
        [StringLength(500)]
        public string HireGroupDescription { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Is Parent
        /// </summary>
        public bool IsParent { get; set; }
        
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
        /// Is ReadOnly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }
        
        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }
        
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
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Parent Hire Group
        /// </summary>
        public virtual HireGroup ParentHireGroup { get; set; }

        /// <summary>
        /// Company 
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Details of this Hire Group
        /// </summary>
        public virtual ICollection<HireGroupDetail> HireGroupDetails { get; set; }
        /// <summary>
        /// Hire Group Up Grades List
        /// </summary>
        public virtual ICollection<HireGroupUpGrade> HireGroupUpGradList { get; set; }

        /// <summary>
        /// Vehicle Associated with this Hire Group
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        
        #endregion
    }
}
