using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    public class DepartmentService : IDepartmentService
    {
        #region Private
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        #endregion
        #region Constructor
        public DepartmentService(IDepartmentRepository xRepository,ICompanyRepository crRepository)
        {
            departmentRepository = xRepository;
            companyRepository = crRepository;
        }
        #endregion

        public DepartmentSearchRequestResponse SearchDepartment(DepartmentSearchRequest request)
        {
            int rowCount;
            return new DepartmentSearchRequestResponse
            {
                Departments = departmentRepository.SearchDepartment(request, out rowCount),
                TotalCount = rowCount
            };
        }

        public void DeleteDepartment(Department department)
        {
            Department dbVersion = departmentRepository.Find(department.DepartmentId);
            if (dbVersion != null)
            {
                departmentRepository.Delete(dbVersion);
                departmentRepository.SaveChanges();
            }
        }

        public IEnumerable<Department> LoadAll()
        {
            return departmentRepository.GetAll();
        }

        public DepartmentBaseDataResponse LoadDepartmentBaseData()
        {

            return new DepartmentBaseDataResponse
            {
               Companies = companyRepository.GetAll()
            };
        }

        public Department SaveUpdateDepartment(Department department)
        {
            Department dbVersion = departmentRepository.Find(department.DepartmentId);
            if (dbVersion != null)
            {
                department.RecLastUpdatedBy = departmentRepository.LoggedInUserIdentity;
                department.RecLastUpdatedDt = DateTime.Now;
                department.RecCreatedBy = dbVersion.RecCreatedBy;
                department.RecCreatedDt = dbVersion.RecCreatedDt;
                department.UserDomainKey = dbVersion.UserDomainKey;
            }
            else
            {
                department.RecCreatedBy = department.RecLastUpdatedBy = departmentRepository.LoggedInUserIdentity;
                department.RecCreatedDt = department.RecLastUpdatedDt = DateTime.Now;
                department.UserDomainKey = 1;
            }
            departmentRepository.Update(department);
            departmentRepository.SaveChanges();
            // To Load the proprties
            return departmentRepository.GetDepartmentWithDetails(department.DepartmentId);
        }
     

    }
}