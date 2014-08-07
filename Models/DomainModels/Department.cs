using System;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Department Domain Model
    /// </summary>
    public class Department
    {
        #region Persisted Properties
        /// <summary>
        /// Department ID
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Department Code
        /// </summary>
        [StringLength(100)]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Department Code
        /// </summary>
        [StringLength(255)]
        public string DepartmentName { get; set; }
        /// <summary>
        /// Department Description
        /// </summary>
        [StringLength(500)]
        public string DepartmentDescription { get; set; }
        /// <summary>
        /// Department Type 
        /// </summary>
        public string DepartmentType { get; set; }
        /// <summary>
        /// Company ID
        /// </summary>
        public int? CompanyId { get; set; }
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
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
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
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties
        /// <summary>
        /// Company
        /// </summary>
        public virtual Company Company{ get; set; }

        #endregion
    }
}
