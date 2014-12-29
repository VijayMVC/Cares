using Cares.Commons;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IAddressRepository addressRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly IEmpJobProgRepository empJobProgRepository;
        private readonly IEmpAuthOperationsWorkplaceRepository empAuthOperationsWorkplaceRepository;
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
            IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository, IAddressTypeRepository addressTypeRepository,
            IAddressRepository addressRepository, IPhoneRepository phoneRepository, IEmpJobProgRepository empJobProgRepository,
            IEmpAuthOperationsWorkplaceRepository empAuthOperationsWorkplaceRepository)
        {
            employeeRepository = empRepository;
            this.empStatusRepository = empStatusRepository;
            this.addressRepository = addressRepository;
            this.phoneRepository = phoneRepository;
            this.empJobProgRepository = empJobProgRepository;
            this.empAuthOperationsWorkplaceRepository = empAuthOperationsWorkplaceRepository;
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
        /// Get All Chauffers
        /// </summary>
        public IEnumerable<Employee> GetAllChauffers(GetRaChaufferRequest request)
        {
            return employeeRepository.GetAllChauffers(request);
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

            #region Add
            if (empDbVersion == null)
            {
                int numberOfEmployessByDomainKey = employeeRepository.GetNumberOfEmployessByDomainKey();
                var domainLicenseDetailwithDomainKey = ClaimHelper.GetDeserializedClaims<DomainLicenseDetailClaim>(CaresUserClaims.DomainLicenseDetail).FirstOrDefault();
                if (domainLicenseDetailwithDomainKey != null)
                    if (domainLicenseDetailwithDomainKey.Employee < numberOfEmployessByDomainKey)
                        throw new CaresException(Resources.Vehicle.Vehicle.ExceedindDomainLimitForVehicleError);
                else
                        throw new InvalidOperationException(Resources.Vehicle.Vehicle.NoDomainLicenseDetailClaim);
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
                if (employee.Addresses != null)
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
            #endregion

            #region Edit
            else
            {
                #region Employee
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
                #endregion

                #region Emp Job Info
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
                #endregion

                #region Emp Docs Info
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
                #endregion

                #region Address List
                if (employee.Addresses != null)
                {
                    foreach (var item in employee.Addresses)
                    {
                        if (
                            empDbVersion.Addresses.All(
                                x =>
                                    x.AddressId != item.AddressId ||
                                    item.AddressId == 0))
                        {
                            item.UserDomainKey = employeeRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            empDbVersion.Addresses.Add(item);
                        }
                    }
                }
                //find missing items
                List<Address> missingAddressItems = new List<Address>();
                foreach (Address dbversionAddressItem in empDbVersion.Addresses)
                {
                    if (employee.Addresses != null && employee.Addresses.All(x => x.AddressId != dbversionAddressItem.AddressId))
                    {
                        missingAddressItems.Add(dbversionAddressItem);
                    }
                    if (employee.Addresses == null)
                    {
                        missingAddressItems.Add(dbversionAddressItem);
                    }
                }
                //remove missing items
                foreach (Address missingAddressItem in missingAddressItems)
                {
                    Address dbVersionMissingItem = empDbVersion.Addresses.First(x => x.AddressId == missingAddressItem.AddressId);
                    if (dbVersionMissingItem.AddressId > 0)
                    {
                        empDbVersion.Addresses.Remove(dbVersionMissingItem);
                        addressRepository.Delete(dbVersionMissingItem);
                        addressRepository.SaveChanges();
                    }
                }


                #endregion

                #region Phone List
                if (employee.PhoneNumbers != null)
                {
                    foreach (var item in employee.PhoneNumbers)
                    {
                        if (
                            empDbVersion.PhoneNumbers.All(
                                x =>
                                    x.PhoneId != item.PhoneId ||
                                    item.PhoneId == 0))
                        {
                            item.UserDomainKey = employeeRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            empDbVersion.PhoneNumbers.Add(item);
                        }
                    }
                }
                //find missing items
                List<Phone> missingPhoneItems = new List<Phone>();
                foreach (Phone dbversionPhoneItem in empDbVersion.PhoneNumbers)
                {
                    if (employee.PhoneNumbers != null && employee.PhoneNumbers.All(x => x.PhoneId != dbversionPhoneItem.PhoneId))
                    {
                        missingPhoneItems.Add(dbversionPhoneItem);
                    }
                    if (employee.PhoneNumbers == null)
                    {
                        missingPhoneItems.Add(dbversionPhoneItem);
                    }
                }
                //remove missing items
                foreach (Phone missingPhoneItem in missingPhoneItems)
                {
                    Phone dbVersionMissingItem = empDbVersion.PhoneNumbers.First(x => x.PhoneId == missingPhoneItem.PhoneId);
                    if (dbVersionMissingItem.PhoneId > 0)
                    {
                        empDbVersion.PhoneNumbers.Remove(dbVersionMissingItem);
                        phoneRepository.Delete(dbVersionMissingItem);
                        phoneRepository.SaveChanges();
                    }
                }
                #endregion

                #region Docs Info
                employee.EmpDocsInfo.UserDomainKey = employeeRepository.UserDomainKey;
                employee.EmpDocsInfo.IsActive = true;
                employee.EmpDocsInfo.IsReadOnly = employee.EmpDocsInfo.IsPrivate = employee.EmpDocsInfo.IsDeleted = false;
                employee.EmpDocsInfo.RecLastUpdatedDt = employee.EmpDocsInfo.RecCreatedDt = DateTime.Now;
                employee.EmpDocsInfo.RecLastUpdatedBy = employee.EmpDocsInfo.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                #endregion

                #region Job Progress List
                if (employee.EmpJobProgs != null)
                {
                    foreach (var item in employee.EmpJobProgs)
                    {
                        if (
                            empDbVersion.EmpJobProgs.All(
                                x =>
                                    x.EmpJobProgId != item.EmpJobProgId ||
                                    item.EmpJobProgId == 0))
                        {
                            item.UserDomainKey = employeeRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            empDbVersion.EmpJobProgs.Add(item);
                        }
                    }
                }
                //find missing items
                List<EmpJobProg> missingEmpJobProgItems = new List<EmpJobProg>();
                foreach (EmpJobProg dbversionEmpJobProgItem in empDbVersion.EmpJobProgs)
                {
                    if (employee.EmpJobProgs != null && employee.EmpJobProgs.All(x => x.EmpJobProgId != dbversionEmpJobProgItem.EmpJobProgId))
                    {
                        missingEmpJobProgItems.Add(dbversionEmpJobProgItem);
                    }
                    if (employee.EmpJobProgs == null)
                    {
                        missingEmpJobProgItems.Add(dbversionEmpJobProgItem);
                    }
                }
                //remove missing items
                foreach (EmpJobProg missingEmpJobProgItem in missingEmpJobProgItems)
                {
                    EmpJobProg dbVersionMissingItem = empDbVersion.EmpJobProgs.First(x => x.EmpJobProgId == missingEmpJobProgItem.EmpJobProgId);
                    if (dbVersionMissingItem.EmpJobProgId > 0)
                    {
                        empDbVersion.EmpJobProgs.Remove(dbVersionMissingItem);
                        empJobProgRepository.Delete(dbVersionMissingItem);
                        empJobProgRepository.SaveChanges();
                    }
                }

                #endregion

                #region Authorized Locations List
                if (employee.EmpAuthOperationsWorkplaces != null)
                {
                    foreach (var item in employee.EmpAuthOperationsWorkplaces)
                    {
                        if (
                            empDbVersion.EmpAuthOperationsWorkplaces.All(
                                x =>
                                    x.EmpAuthOperationsWorkplaceId != item.EmpAuthOperationsWorkplaceId ||
                                    item.EmpAuthOperationsWorkplaceId == 0))
                        {
                            item.UserDomainKey = employeeRepository.UserDomainKey;
                            item.RecLastUpdatedDt = item.RecCreatedDt = DateTime.Now;
                            item.RecLastUpdatedBy = item.RecCreatedBy = employeeRepository.LoggedInUserIdentity;
                            item.RowVersion = 0;

                            empDbVersion.EmpAuthOperationsWorkplaces.Add(item);
                        }
                    }
                }
                //find missing items
                List<EmpAuthOperationsWorkplace> missingLocationItems = new List<EmpAuthOperationsWorkplace>();
                foreach (EmpAuthOperationsWorkplace dbversionLocationItem in empDbVersion.EmpAuthOperationsWorkplaces)
                {
                    if (employee.EmpAuthOperationsWorkplaces != null && employee.EmpAuthOperationsWorkplaces.All(x => x.EmpAuthOperationsWorkplaceId != dbversionLocationItem.EmpAuthOperationsWorkplaceId))
                    {
                        missingLocationItems.Add(dbversionLocationItem);
                    }
                    if (employee.EmpAuthOperationsWorkplaces == null)
                    {
                        missingLocationItems.Add(dbversionLocationItem);
                    }
                }
                //remove missing items
                foreach (EmpAuthOperationsWorkplace missingLocationItem in missingLocationItems)
                {
                    EmpAuthOperationsWorkplace dbVersionMissingItem = empDbVersion.EmpAuthOperationsWorkplaces.First(x => x.EmpAuthOperationsWorkplaceId == missingLocationItem.EmpAuthOperationsWorkplaceId);
                    if (dbVersionMissingItem.EmpAuthOperationsWorkplaceId > 0)
                    {
                        empDbVersion.EmpAuthOperationsWorkplaces.Remove(dbVersionMissingItem);
                        empAuthOperationsWorkplaceRepository.Delete(dbVersionMissingItem);
                        empAuthOperationsWorkplaceRepository.SaveChanges();
                    }
                }

                #endregion

            }
            #endregion

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

