using System;
using System.Collections.Generic;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Department Service
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        #region Private
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Department Constructor
        /// </summary>
        public DepartmentService(IDepartmentRepository xRepository,ICompanyRepository crRepository)
        {
            departmentRepository = xRepository;
            companyRepository = crRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Search Department
        /// </summary>
        public DepartmentSearchRequestResponse SearchDepartment(DepartmentSearchRequest request)
        {
            int rowCount;
            return new DepartmentSearchRequestResponse
            {
                Departments = departmentRepository.SearchDepartment(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Department
        /// </summary>
        public void DeleteDepartment(Department department)
        {
            Department dbVersion = departmentRepository.Find(department.DepartmentId);
            if (dbVersion != null)
            {
                departmentRepository.Delete(dbVersion);
                departmentRepository.SaveChanges();
            }
        }

        /// <summary>
        /// Load All DEpartments
        /// </summary>
        public IEnumerable<Department> LoadAll()
        {
            return departmentRepository.GetAll();
        }

        /// <summary>
        /// Load Department Base Data
        /// </summary>
        public DepartmentBaseDataResponse LoadDepartmentBaseData()
        {

            return new DepartmentBaseDataResponse
            {
               Companies = companyRepository.GetAll()
            };
        }

        /// <summary>
        /// Save or Update Department
        /// </summary>
        public Department SaveUpdateDepartment(Department department)
        {
            Department dbVersion = departmentRepository.Find(department.DepartmentId);
            if (!departmentRepository.IsDepartmentCodeExists(department))
            {
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
            throw new CaresException(Resources.Organization.Department.DepartmentWithSameCodeAlreadyExistsError);
        }
        #endregion
    }
}