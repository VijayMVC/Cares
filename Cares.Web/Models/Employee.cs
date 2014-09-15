using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Web Model
    /// </summary>
    public sealed class Employee
    {
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
        public char? Gender { get; set; }

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
        /// Job Info
        /// </summary>
        public EmpJobInfo EmpJobInfo { get; set; }

        /// <summary>
        /// List Of Address
        /// </summary>
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Employee Phone Number List
        /// </summary>
        public List<Phone> PhoneNumbers { get; set; }

        /// <summary>
        /// Employee Docs Info
        /// </summary>
        public EmpDocsInfo EmpDocsInfo { get; set; }

        /// <summary>
        /// Employee Job Progress List
        /// </summary>
        public List<EmpJobProg> EmpJobProgs { get; set; }

        /// <summary>
        /// Employee Auth Operations Workplace List
        /// </summary>
        public List<EmpAuthOperationsWorkplace> AuthorizedLocations { get; set; }
    }
}