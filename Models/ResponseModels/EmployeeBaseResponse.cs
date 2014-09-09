using System.Collections.Generic;
using Cares.Models.DomainModels;
using PhoneType = Cares.Models.CommonTypes.PhoneType;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Employee Base Domin Response
    /// </summary>
    public sealed class EmployeeBaseResponse
    {
        /// <summary>
        /// Employee Statuses
        /// </summary>
        public IEnumerable<EmpStatus> EmpStatuses { get; set; }

        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// Job Types
        /// </summary>
        public IEnumerable<JobType> JobTypes { get; set; }

        /// <summary>
        /// Designations
        /// </summary>
        public IEnumerable<Designation> Designations { get; set; }

        /// <summary>
        /// Designation Grades
        /// </summary>
        public IEnumerable<DesigGrade> DesigGrades { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Work Places
        /// </summary>
        public IEnumerable<WorkPlace> WorkPlaces { get; set; }

        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<Country> Countries { get; set; }

        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<Region> Regions { get; set; }

        /// <summary>
        /// Sub Regions
        /// </summary>
        public IEnumerable<SubRegion> SubRegions { get; set; }

        /// <summary>
        /// Cities
        /// </summary>
        public IEnumerable<City> Cities { get; set; }

        /// <summary>
        /// Areas
        /// </summary>
        public IEnumerable<Area> Areas { get; set; }

        /// <summary>
        /// Phone Types
        /// </summary>
        public IEnumerable<DomainModels.PhoneType> PhoneTypes { get; set; }

        /// <summary>
        /// License Types
        /// </summary>
        public IEnumerable<LicenseType> LicenseTypes { get; set; }

        /// <summary>
        /// Operations
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Operations Work Places
        /// </summary>
        public IEnumerable<OperationsWorkPlace> OperationsWorkPlaces { get; set; }

        /// <summary>
        /// Supervisors
        /// </summary>
        public IEnumerable<Employee> Supervisors { get; set; }


    }
}
