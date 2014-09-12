using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Employee Base Web Response
    /// </summary>
    public sealed class EmployeeBaseResponse
    {
        /// <summary>
        /// Employee Statuses
        /// </summary>
        public IEnumerable<EmpStatusDropDown> EmpStatuses { get; set; }

        /// <summary>
        /// Address Types Drop down
        /// </summary>
        public IEnumerable<AddressTypeDropDown> AddressTypes { get; set; }

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<CompanyDropDown> Companies { get; set; }

        /// <summary>
        /// Job Types
        /// </summary>
        public IEnumerable<JobTypeDropDown> JobTypes { get; set; }

        /// <summary>
        /// Designations
        /// </summary>
        public IEnumerable<DesignationDropDown> Designations { get; set; }

        /// <summary>
        /// Designation Grades
        /// </summary>
        public IEnumerable<DesigGradeDropDown> DesigGrades { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public IEnumerable<DepartmentDropDown> Departments { get; set; }

        /// <summary>
        /// Work Places
        /// </summary>
        public IEnumerable<WorkPlaceDropdown> WorkPlaces { get; set; }

        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<CountryDropDown> Countries { get; set; }

        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<RegionDropDown> Regions { get; set; }

        /// <summary>
        /// Sub Regions
        /// </summary>
        public IEnumerable<SubRegionDropDown> SubRegions { get; set; }

        /// <summary>
        /// Cities
        /// </summary>
        public IEnumerable<CityDropDown> Cities { get; set; }

        /// <summary>
        /// Areas
        /// </summary>
        public IEnumerable<AreaDropDown> Areas { get; set; }

        /// <summary>
        /// Phone Types
        /// </summary>
        public IEnumerable<PhoneTypeDropDown> PhoneTypes { get; set; }

        /// <summary>
        /// License Types
        /// </summary>
        public IEnumerable<LicenseTypeDropDown> LicenseTypes { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<OperationDropDown> Operations { get; set; }

        /// <summary>
        /// Operations Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// Supervisors
        /// </summary>
        public IEnumerable<EmployeeDropDown> Supervisors { get; set; }
    }
}