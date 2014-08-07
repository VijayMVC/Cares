using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.DomainModels;

namespace Cares.Models.DomainModels
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
        public int CompanyId { get; set; }
        /// <summary>
        /// Parent Company
        /// </summary>

        public int? ParentCompanyId { get; set; }
        /// <summary>
        /// Organization Group ID
        /// </summary>
        public int OrgGroupId { get; set; }
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
        public int BusinessSegmentId { get; set; }
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
        /// Parent Company
        /// </summary>
        [ForeignKey("ParentCompanyId")]
        public virtual Company ParentCompany { get; set; }
        /// <summary>
        /// Organization Group
        /// </summary>
        public virtual OrgGroup OrgGroup { get; set; }
        /// <summary>
        /// Business Segment
        /// </summary>
        public virtual BusinessSegment BusinessSegment { get; set; }

        #endregion
    }
}
