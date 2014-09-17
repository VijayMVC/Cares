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
        private readonly IDesignGradeRepository desigGradeRepository;
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
            IJobTypeRepository jobTypeRepository, IDesignationRepository designationRepository, IDesignGradeRepository desigGradeRepository,
            IDepartmentRepository departmentRepository, IWorkplaceRepository workplaceRepository, ICountryRepository countryRepository,
            IRegionRepository regionRepository, ISubRegionRepository subRegionRepository, ICityRepository cityRepository,
            IAreaRepository areaRepository, IPhoneTypeRepository phoneTypeRepository, ILicenseTypeRepository licenseTypeRepository,
            IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository, IAddressTypeRepository addressTypeRepository)
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
        public Employee FindById(long employeeId)
        {
            return employeeRepository.Find(employeeId);
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public void DeleteEmployee(Employee employee)
        {
            employeeRepository.Delete(employee);
            employeeRepository.SaveChanges();
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

                ////Address List
                //if (employee.Addresses!=null)
                //{
                //    foreach (var item in employee.Addresses)
                //    {
                //        item.UserDomainKey = employeeRepository.UserDomainKey;
                //        item.IsActive = true;
                //        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                //        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                //        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                //        item.RowVersion = 0;
                //    }
                //}
                ////Phone List
                //if (employee.PhoneNumbers != null)
                //{
                //    foreach (var item in employee.PhoneNumbers)
                //    {
                //        item.UserDomainKey = employeeRepository.UserDomainKey;
                //        item.IsActive = true;
                //        item.IsReadOnly = item.IsPrivate = item.IsDeleted = false;
                //        item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                //        item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                //        item.RowVersion = 0;
                //    }
                //}

                //Docs Info
                employee.EmpDocsInfo.UserDomainKey = employeeRepository.UserDomainKey;
                employee.EmpDocsInfo.IsActive = true;
                employee.EmpDocsInfo.IsReadOnly = employee.EmpDocsInfo.IsPrivate = employee.EmpDocsInfo.IsDeleted = false;
                employee.EmpDocsInfo.RecLastUpdatedDt = employee.EmpDocsInfo.RecCreatedDt = DateTime.Now;
                employee.EmpDocsInfo.RecLastUpdatedBy = employee.EmpDocsInfo.RecCreatedBy = employeeRepository.LoggedInUserIdentity;

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
                
                empDbVersion.EmployeeId = employee.EmployeeId;
                empDbVersion.CompanyId = employee.CompanyId;
                empDbVersion.EmpStatusId = employee.EmpStatusId;
                empDbVersion.Gender = employee.Gender;
                empDbVersion.DOB = employee.DOB;
                empDbVersion.EmpCode = employee.EmpCode;
                empDbVersion.EmpFName = employee.EmpFName;
                empDbVersion.EmpLName = employee.EmpLName;
                empDbVersion.EmpMName = employee.EmpMName;
                empDbVersion.Notes = employee.Notes;
                empDbVersion.Notes1 = employee.Notes1;
                empDbVersion.Notes2 = employee.Notes2;
                empDbVersion.Notes3 = employee.Notes3;
                empDbVersion.Notes4 = employee.Notes4;
                empDbVersion.Notes5 = employee.Notes5;
                empDbVersion.NationalityId = employee.NationalityId;
                empDbVersion.RecLastUpdatedBy = employeeRepository.LoggedInUserIdentity;
                empDbVersion.RecLastUpdatedDt = DateTime.Now;
                //Emp Job Info
                empDbVersion.EmpJobInfo.DepartmentId = employee.EmpJobInfo.DepartmentId;
                empDbVersion.EmpJobInfo.DesigGradeId = employee.EmpJobInfo.DesigGradeId;
                empDbVersion.EmpJobInfo.DesignationId = employee.EmpJobInfo.DesignationId;
                empDbVersion.EmpJobInfo.JobTypeId = employee.EmpJobInfo.JobTypeId;
                empDbVersion.EmpJobInfo.SupervisorId = employee.EmpJobInfo.SupervisorId;
                empDbVersion.EmpJobInfo.WorkPlaceId = employee.EmpJobInfo.WorkPlaceId;
                empDbVersion.EmpJobInfo.JoiningDt = employee.EmpJobInfo.JoiningDt;
                empDbVersion.EmpJobInfo.Salary = employee.EmpJobInfo.Salary;
                empDbVersion.EmpJobInfo.RecLastUpdatedBy = employeeRepository.LoggedInUserIdentity;
                empDbVersion.EmpJobInfo.RecLastUpdatedDt = DateTime.Now;
                //Emp Docs Info
                empDbVersion.EmpDocsInfo.InsuranceCompany = employee.EmpDocsInfo.InsuranceCompany;
                empDbVersion.EmpDocsInfo.InsuranceDt = employee.EmpDocsInfo.InsuranceDt;
                empDbVersion.EmpDocsInfo.InsuranceNo = employee.EmpDocsInfo.InsuranceNo;
                empDbVersion.EmpDocsInfo.IqamaExpDt = employee.EmpDocsInfo.IqamaExpDt;
                empDbVersion.EmpDocsInfo.IqamaNo = employee.EmpDocsInfo.IqamaNo;
                empDbVersion.EmpDocsInfo.LicenseExpDt = employee.EmpDocsInfo.LicenseExpDt;
                empDbVersion.EmpDocsInfo.LicenseNo = employee.EmpDocsInfo.LicenseNo;
                empDbVersion.EmpDocsInfo.LicenseTypeId = employee.EmpDocsInfo.LicenseTypeId;
                empDbVersion.EmpDocsInfo.PassportCountryId = employee.EmpDocsInfo.PassportCountryId;
                empDbVersion.EmpDocsInfo.VisaIssueCountryId = employee.EmpDocsInfo.VisaIssueCountryId;
                empDbVersion.EmpDocsInfo.PassportNo = employee.EmpDocsInfo.PassportNo;
                empDbVersion.EmpDocsInfo.PassportExpDt = employee.EmpDocsInfo.PassportExpDt;
                empDbVersion.EmpDocsInfo.VisaNo = employee.EmpDocsInfo.VisaNo;
                empDbVersion.EmpDocsInfo.VisaExpDt = employee.EmpDocsInfo.VisaExpDt;
                empDbVersion.EmpDocsInfo.RecLastUpdatedBy = employeeRepository.LoggedInUserIdentity;
                empDbVersion.EmpDocsInfo.RecLastUpdatedDt = DateTime.Now;


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

