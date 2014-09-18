using System;
using System.Collections.Generic;

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
        public long CompanyId { get; set; }

        /// <summary>
        /// Employee Status ID
        /// </summary>
        public long EmpStatusId { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string EmpCode { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string EmpFName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        public string EmpMName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string EmpLName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public short? NationalityId { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Notes1
        /// </summary>
        public string Notes1 { get; set; }

        /// <summary>
        /// Notes2
        /// </summary>
        public string Notes2 { get; set; }

        /// <summary>
        /// Note3
        /// </summary>
        public string Notes3 { get; set; }

        /// <summary>
        /// Notes4
        /// </summary>
        public string Notes4 { get; set; }

        /// <summary>
        /// Notes5
        /// </summary>
        public string Notes5 { get; set; }

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
        /// 
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
        /// Employee Job Infos
        /// </summary>
        public virtual ICollection<EmpJobProg> EmpJobInfos { get; set; }

        /// <summary>
        /// Employee Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Phone Numbers
        /// </summary>
        public virtual ICollection<Phone> PhoneNumbers { get; set; }

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
