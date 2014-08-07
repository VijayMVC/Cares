using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DomainModels
{
    /// <summary>
    /// Domain Model for Company
    /// </summary>
    public class Company
    {
        #region Persisted Properties

        /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Parent Company
        /// </summary>
        [ForeignKey("ParentCompany")]
        public long? ParentCompanyId { get; set; }

        /// <summary>
        /// Organization Group ID
        /// </summary>
        [ForeignKey("OrgGroup")]
        public long? OrgGroupId { get; set; }

        /// <summary>
        /// Company Code
        /// </summary>
        [StringLength(100)]
        public string CompanyCode { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        [StringLength(250)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Company Description
        /// </summary>
        [StringLength(500)]
        public string CompanyDescription { get; set; }

        /// <summary>
        /// Company Legal Name
        /// </summary>
        [StringLength(255)]
        public string CompanyLegalName { get; set; }

        /// <summary>
        /// Company Registration Number
        /// </summary>
        [StringLength(100)]
        public string CrNumber { get; set; }

        /// <summary>
        /// Universal Access Number
        /// </summary>
        [StringLength(20)]
        public string Uan { get; set; }

        /// <summary>
        /// NTN
        /// </summary>
        [StringLength(100)]
        public string Ntn { get; set; }

        /// <summary>
        /// Paid Capital
        /// </summary>
        public double PaidUpCapital { get; set; }

        /// <summary>
        /// Business Segment ID
        /// </summary>
        [ForeignKey("BusinessSegment")]
        public short BusinessSegmentId { get; set; }

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
        /// Parent Company
        /// </summary>
        public virtual Company ParentCompany { get; set; }
        
        /// <summary>
        /// Organization Group
        /// </summary>
        public virtual OrgGroup OrgGroup { get; set; }
        
        /// <summary>
        /// Business Segment
        /// </summary>
        public virtual BusinessSegment BusinessSegment { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }

        /// <summary>
        /// Hire Groups this company has
        /// </summary>
        public virtual ICollection<HireGroup> HireGroups { get; set; }

        /// <summary>
        /// Work Locations this company has
        /// </summary>
        public virtual ICollection<WorkLocation> WorkLocations { get; set; }

        #endregion
    }
}
