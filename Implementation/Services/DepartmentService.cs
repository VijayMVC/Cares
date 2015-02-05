using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IOperationRepository operationRepository;

        #endregion
        #region Constructor
        /// <summary>
        /// Department Constructor
        /// </summary>
        public DepartmentService(IDepartmentRepository xRepository, ICompanyRepository crRepository, IOperationRepository operationRepository)
        {
            departmentRepository = xRepository;
            companyRepository = crRepository;
            this.operationRepository = operationRepository;
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
        public void DeleteDepartment(long departmentId)
        {
            Department dbVersion = departmentRepository.Find(departmentId);
            if (!operationRepository.IsDepartmentAssociatedWithAnyOperation(departmentId))
            {
                if (dbVersion != null)
                {
                    departmentRepository.Delete(dbVersion);
                    departmentRepository.SaveChanges();
                    return;
                }
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                         "Department with Id {0} not found!", departmentId));
            }
            throw new CaresException(Resources.Organization.Department.DepartmentIsAssociatedWithOperationError);
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
                    dbVersion.CompanyId = department.CompanyId;
                    dbVersion.DepartmentCode = department.DepartmentCode;
                    dbVersion.DepartmentName = department.DepartmentName;
                    dbVersion.DepartmentDescription = department.DepartmentDescription;
                    dbVersion.RecLastUpdatedBy = departmentRepository.LoggedInUserIdentity;
                    dbVersion.RecLastUpdatedDt = DateTime.Now;
                    dbVersion.RowVersion = dbVersion.RowVersion + 1;
                    departmentRepository.Update(dbVersion);
                }
                else
                {
                    department.RecCreatedBy = department.RecLastUpdatedBy = departmentRepository.LoggedInUserIdentity;
                    department.RecCreatedDt = department.RecLastUpdatedDt = DateTime.Now;
                    department.UserDomainKey = departmentRepository.UserDomainKey;
                    departmentRepository.Add(department);
                }
                
                departmentRepository.SaveChanges();
                // To Load the proprties
                return departmentRepository.GetDepartmentWithDetails(department.DepartmentId);
            }
            throw new CaresException(Resources.Organization.Department.DepartmentWithSameCodeAlreadyExistsError);
        }
        #endregion
    }
}