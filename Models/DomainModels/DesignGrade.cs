using System;
using System.Collections.Generic;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Desig Grade Domain Model
    /// </summary>
    public class DesignGrade
    {
        #region Persisted Properties

        /// <summary>
        /// Designation Grade ID
        /// </summary>
        [Key]
        public long DesigGradeId { get; set; }

        /// <summary>
        /// Designation Grade Code
        /// </summary>
        public string DesigGradeCode { get; set; }

        /// <summary>
        /// Designation Grade Code
        /// </summary>
        public string DesigGradeName { get; set; }

        /// <summary>
        /// Designation Grade Description
        /// </summary>
        public string DesigGradeDescription { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

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
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Employee Job Infos
        /// </summary>
        public virtual ICollection<EmpJobInfo> EmployeeJobInfos { get; set; }

        #endregion

    }
}
