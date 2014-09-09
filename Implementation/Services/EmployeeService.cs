using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
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

        public EmployeeService(IEmployeeRepository empRepository, IEmployeeRepository empStatusRepository, ICompanyRepository companyRepository,
            IJobTypeRepository jobTypeRepository, IDesignationRepository designationRepository, IDesigGradeRepository desigGradeRepository,
            IDepartmentRepository departmentRepository, IWorkplaceRepository workplaceRepository, ICountryRepository countryRepository,
            IRegionRepository regionRepository, ISubRegionRepository subRegionRepository, ICityRepository cityRepository,
            IAreaRepository areaRepository, IPhoneTypeRepository phoneTypeRepository, ILicenseTypeRepository licenseTypeRepository,
            IOperationRepository operationRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
        {
            employeeRepository = empRepository;
            empStatusRepository = empStatusRepository;
            companyRepository = companyRepository;
            jobTypeRepository = jobTypeRepository;
            designationRepository = designationRepository;
            desigGradeRepository = desigGradeRepository;
            departmentRepository = departmentRepository;
            workplaceRepository = workplaceRepository;
            regionRepository = regionRepository;
            countryRepository = countryRepository;
            subRegionRepository = subRegionRepository;
            cityRepository = cityRepository;
            areaRepository = areaRepository;
            phoneTypeRepository = phoneTypeRepository;
            licenseTypeRepository = licenseTypeRepository;
            operationRepository = operationRepository;
            operationsWorkPlaceRepository = operationsWorkPlaceRepository;
        }

        public EmployeeResponse LoadAll(EmployeeSearchRequest searchRequest)
        {
            return employeeRepository.GetAllEmployees(searchRequest);
        }

        public Employee Find(int id)
        {
            return employeeRepository.Find(id);
        }

        public void Delete(Employee product)
        {
            employeeRepository.Delete(product);
            employeeRepository.SaveChanges();
        }

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
            Employee productDbVersion = employeeRepository.GetEmployeeByName(x.Name, Convert.ToInt32(x.Id));
            return productDbVersion == null;
        }

        public bool Update(Employee product)
        {

            //Product productDbVersion =  productRepository.Find(product.Id);

            //if (productDbVersion != null)
            //{
            //    //productDbVersion.Category =
            //    //    categoryRepository.GetAllCategories().Where(x => x.Id == product.CategoryId).FirstOrDefault();
            //    using (TransactionScope transaction = new TransactionScope())
            //    {
            //        productDbVersion.Category.Name = "KHurram U" + DateTime.Now.Minute;
            //        productDbVersion.Name = product.Name;

            //        //Thread.Sleep(20*1000);
            //        productRepository.SaveChanges();
            //        throw new Exception();

            //        transaction.Complete();

            //    }
            //}

            if (Validate(product))
            {
                employeeRepository.Update(product);
                employeeRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Employee> FindByDepartment(int depId)
        {
            return employeeRepository.GetEmployeesByDepartment(depId);
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
                       
                   };
        }
    }
}
