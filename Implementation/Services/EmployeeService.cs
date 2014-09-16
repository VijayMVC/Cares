using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Employee Service
    /// </summary>
    public sealed class EmployeeService : IEmployeeService
    {
        #region Private
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmpStatusRepository empStatusRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IJobTypeRepository jobTypeRepository;
        private readonly IDesignationRepository designationRepository;
        private readonly IDesigGradeRepository desigGradeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IWorkplaceRepository workplaceRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ISubRegionRepository subRegionRepository;
        private readonly ICityRepository cityRepository;
        private readonly IAreaRepository areaRepository;
        private readonly IPhoneTypeRepository phoneTypeRepository;
        private readonly ILicenseTypeRepository licenseTypeRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        private readonly IAddressTypeRepository addressTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="empRepository"></param>
        /// <param name="empStatusRepository"></param>
        /// <param name="companyRepository"></param>
        /// <param name="jobTypeRepository"></param>
        /// <param name="designationRepository"></param>
        /// <param name="desigGradeRepository"></param>
        /// <param name="departmentRepository"></param>
        /// <param name="workplaceRepository"></param>
        /// <param name="countryRepository"></param>
        /// <param name="regionRepository"></param>
        /// <param name="subRegionRepository"></param>
        /// <param name="cityRepository"></param>
        /// <param name="areaRepository"></param>
        /// <param name="phoneTypeRepository"></param>
        /// <param name="licenseTypeRepository"></param>
        /// <param name="operationRepository"></param>
        /// <param name="operationsWorkPlaceRepository"></param>
        public EmployeeService(IEmployeeRepository empRepository, IEmpStatusRepository empStatusRepository, ICompanyRepository companyRepository,
            IJobTypeRepository jobTypeRepository, IDesignationRepository designationRepository, IDesigGradeRepository desigGradeRepository,
            IDepartmentRepository departmentRepository, IWorkplaceRepository workplaceRepository, ICountryRepository countryRepository,
            IRegionRepository regionRepository, ISubRegionRepository subRegionRepository, ICityRepository cityRepository,
            IAreaRepository areaRepository, IPhoneTypeRepository phoneTypeRepository, ILicenseTypeRepository licenseTypeRepository,
            IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository,IAddressTypeRepository addressTypeRepository)
        {
            employeeRepository = empRepository;
            this.empStatusRepository = empStatusRepository;
            this.companyRepository = companyRepository;
            this.jobTypeRepository = jobTypeRepository;
            this.designationRepository = designationRepository;
            this.desigGradeRepository = desigGradeRepository;
            this.departmentRepository = departmentRepository;
            this.workplaceRepository = workplaceRepository;
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.subRegionRepository = subRegionRepository;
            this.cityRepository = cityRepository;
            this.areaRepository = areaRepository;
            this.phoneTypeRepository = phoneTypeRepository;
            this.licenseTypeRepository = licenseTypeRepository;
            this.operationRepository = operationRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
            this.addressTypeRepository = addressTypeRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Loa dAll Employees
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public EmployeeSearchResponse LoadAll(EmployeeSearchRequest searchRequest)
        {
            return employeeRepository.GetAllEmployees(searchRequest);
        }

        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee Find(int employeeId)
        {
            return employeeRepository.Find(employeeId);
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="product"></param>
        public void Delete(Employee product)
        {
            employeeRepository.Delete(product);
            employeeRepository.SaveChanges();
        }

        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Add(Employee product)
        {
            if (Validate(product))
            {
                employeeRepository.Add(product);
                employeeRepository.SaveChanges();
                return true;
            }
            return false;
        }

        private bool Validate(Employee x)
        {
            Employee productDbVersion = employeeRepository.GetEmployeeByName(x.EmpFName, Convert.ToInt32(x.EmployeeId));
            return productDbVersion == null;
        }

        /// <summary>
        /// Get Base Data
        /// </summary>
        /// <returns></returns>
        public EmployeeBaseResponse GetBaseData()
        {
            return new EmployeeBaseResponse
           {
               EmpStatuses = empStatusRepository.GetAll(),
               Companies = companyRepository.GetAll(),
               JobTypes = jobTypeRepository.GetAll(),
               Departments = departmentRepository.GetAll(),
               DesigGrades = desigGradeRepository.GetAll(),
               WorkPlaces = workplaceRepository.GetAll(),
               Regions = regionRepository.GetAll(),
               Countries = countryRepository.GetAll(),
               SubRegions = subRegionRepository.GetAll(),
               Cities = cityRepository.GetAll(),
               Areas = areaRepository.GetAll(),
               PhoneTypes = phoneTypeRepository.GetAll(),
               LicenseTypes = licenseTypeRepository.GetAll(),
               Operations = operationRepository.GetAll(),
               OperationsWorkPlaces = operationsWorkPlaceRepository.GetAll(),
               Supervisors = employeeRepository.GetAll(),
               Designations = designationRepository.GetAll(),
               AddressTypes = addressTypeRepository.GetAll()
           };
        }

        /// <summary>
        /// Add/Edit Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee SaveEmployee(Employee employee)
        {
            Employee empDbVersion = employeeRepository.Find(employee.EmployeeId);
            
            if (empDbVersion == null)
            {
                
                employee.UserDomainKey = employeeRepository.UserDomainKey;
                employee.IsActive = true;
                employee.IsReadOnly = employee.IsPrivate = employee.IsDeleted = false;
                employee.RecLastUpdatedDt = employee.RecCreatedDt = DateTime.Now;
                employee.RecLastUpdatedBy = employee.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                employee.RowVersion = 0;

                //Job Info
                employee.EmpJobInfo.UserDomainKey = employeeRepository.UserDomainKey;
                employee.EmpJobInfo.IsActive = true;
                employee.EmpJobInfo.IsReadOnly = employee.EmpJobInfo.IsPrivate = employee.EmpJobInfo.IsDeleted = false;
                employee.EmpJobInfo.RecLastUpdatedDt = employee.EmpJobInfo.RecCreatedDt = DateTime.Now;
                employee.EmpJobInfo.RecLastUpdatedBy = employee.EmpJobInfo.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                
                //Address List
                if (employee.Addresses!=null)
                {
                    foreach (var item in employee.Addresses)
                    {
                        item.UserDomainKey = employeeRepository.UserDomainKey;
                        item.IsActive = true;
                        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }
                //Phone List
                if (employee.PhoneNumbers != null)
                {
                    foreach (var item in employee.PhoneNumbers)
                    {
                        item.UserDomainKey = employeeRepository.UserDomainKey;
                        item.IsActive = true;
                        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }

                 //Docs Info
                employee.EmpJobInfo.UserDomainKey = employeeRepository.UserDomainKey;
                employee.EmpJobInfo.IsActive = true;
                employee.EmpJobInfo.IsReadOnly = employee.EmpJobInfo.IsPrivate = employee.EmpJobInfo.IsDeleted = false;
                employee.EmpJobInfo.RecLastUpdatedDt = employee.EmpJobInfo.RecCreatedDt = DateTime.Now;
                employee.EmpJobInfo.RecLastUpdatedBy = employee.EmpJobInfo.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
              
                //Job Progress List
                if (employee.EmpJobProgs != null)
                {
                    foreach (var item in employee.EmpJobProgs)
                    {
                        item.UserDomainKey = employeeRepository.UserDomainKey;
                        item.IsActive = true;
                        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }

                //Authorized Locations List
                if (employee.EmpAuthOperationsWorkplaces != null)
                {
                    foreach (var item in employee.EmpAuthOperationsWorkplaces)
                    {
                        item.UserDomainKey = employeeRepository.UserDomainKey;
                        item.IsActive = true;
                        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                        item.RowVersion = 0;
                    }
                }
                employeeRepository.Add(employee);

            }
            else
            {
                
                
            }
            employeeRepository.SaveChanges();

            return employeeRepository.Find(employee.EmployeeId);
        }

        /// <summary>
        /// Get Employee Detail
        /// </summary>
        /// <returns></returns>
        public Employee GetEmployeeDetail(long employeeId)
        {
            return employeeRepository.Find(employeeId);
        }
        #endregion
    }
}

