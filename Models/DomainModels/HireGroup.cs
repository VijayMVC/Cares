using System;
using System.Collections.Generic;

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
        public long UserDomainKey { get; set; }
        
        /// <summary>
        /// Parent Hire Group ID
        /// </summary>
        public long? ParentHireGroupId { get; set; }
        
        /// <summary>
        /// Company ID
        /// </summary>
        public long? CompanyId { get; set; }
        
        /// <summary>
        ///Hire Group Name
        /// </summary>
        public string HireGroupName { get; set; }
        
        /// <summary>
        /// Hire Group Code
        /// </summary>
        public string HireGroupCode { get; set; }

        /// <summary>
        /// Hire Group Description
        /// </summary>
        public string HireGroupDescription { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Is Parent
        /// </summary>
        public bool IsParent { get; set; }
        
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
        public string RecLastUpdatedBy { get; set; }
        
        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
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

        /// <summary>
        /// Allowed Hire Group Up Grades
        /// </summary>
        public virtual ICollection<HireGroupUpGrade> AllowedHireGroupUpGrades { get; set; }
        
        #endregion
    }
}
