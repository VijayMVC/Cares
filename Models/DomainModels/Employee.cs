using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Employee Domain Model
    /// </summary>
    public class Employee
    {
        #region Persisted Properties

        /// <summary>
        /// Id
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        [ForeignKey("Company"), Required]
        public long CompanyId { get; set; }

        /// <summary>
        /// Employee Status ID
        /// </summary>
        [ForeignKey("EmpStatus"), Required]
        public long EmpStatusId { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [StringLength(100), Required]
        public string EmpCode { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [StringLength(225), Required]
        public string EmpFName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [StringLength(225)]
        public string EmpMName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [StringLength(225)]
        public string EmpLName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [Required]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public char? Gender { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        [ForeignKey("Nationality")]
        public short? NationalityId { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        [StringLength(500)]
        public string Notes { get; set; }

        /// <summary>
        /// Notes1
        /// </summary>
        [StringLength(500)]
        public string Notes1 { get; set; }

        /// <summary>
        /// Notes2
        /// </summary>
        [StringLength(500)]
        public string Notes2 { get; set; }

        /// <summary>
        /// Note3
        /// </summary>
        [StringLength(500)]
        public string Notes3 { get; set; }

        /// <summary>
        /// Notes4
        /// </summary>
        [StringLength(500)]
        public string Notes4 { get; set; }

        /// <summary>
        /// Notes5
        /// </summary>
        [StringLength(500)]
        public string Notes5 { get; set; }

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
        /// 
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

        #region references

        /// <summary>
        /// Company
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Employee Status
        /// </summary>
        public virtual EmpStatus EmpStatus { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public virtual Country Nationality { get; set; }

        /// <summary>
        /// Employee Job Info
        /// </summary>
        public virtual EmpJobInfo EmpJobInfo { get; set; }

        /// <summary>
        /// Employee Addresses
        /// </summary>
        //public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Phone Numbers
        /// </summary>
        //public virtual ICollection<Phone> PhoneNumbers { get; set; }

        /// <summary>
        /// Employee Documents Info
        /// </summary>
        public virtual EmpDocsInfo EmpDocsInfo { get; set; }

        /// <summary>
        /// Employee Job Progress
        /// </summary>
        public virtual ICollection<EmpJobProg> EmpJobProgs { get; set; }

        /// <summary>
        /// Employee  Authorized Operations Workplace
        /// </summary>
        public virtual ICollection<EmpAuthOperationsWorkplace> EmpAuthOperationsWorkplaces { get; set; }

        
        #endregion
    }
}
