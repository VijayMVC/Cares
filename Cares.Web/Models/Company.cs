using System;
namespace Cares.Web.Models
{
    /// <summary>
    /// Company Model
    /// </summary>
    public class Company
    { /// <summary>
        /// Company ID
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// Parent Company id
        /// </summary>
        public long? ParentCompanyId { get; set; }
        /// <summary>
        /// Parent Company Name
        /// </summary>
        public string ParentCompanyName { get; set; }
        /// <summary>
        /// Organization Group ID
        /// </summary>
        public long? OrgGroupId { get; set; }
        /// <summary>
        /// Organization Group Name
        /// </summary>
        public string OrgGroupName { get; set; }
        /// <summary>
        /// Company Code
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company Description
        /// </summary>
        public string CompanyDescription { get; set; }
        /// <summary>
        /// Company Legal Name
        /// </summary>
        public string CompanyLegalName { get; set; }
        /// <summary>
        /// Company Registration Number
        /// </summary>
        public string CrNumber { get; set; }
        /// <summary>
        /// Universal Access Number
        /// </summary>
        public string Uan { get; set; }
        /// <summary>
        /// NTN
        /// </summary>
        public string Ntn { get; set; }
        /// <summary>
        /// Paid Capital
        /// </summary>
        public double PaidUpCapital { get; set; }

        /// <summary>
        /// Business Segment ID
        /// </summary>
        public short BusinessSegmentId { get; set; }
        /// <summary>
        /// Business Segment name
        /// </summary>
        public string BusinessSegmentName { get; set; }
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
    }
}