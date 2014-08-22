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
    /// Operation Service
    /// </summary>
    public class OperationService : IOperationService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICompanyRepository companyRepository;

        #endregion
        #region Constructor
        public OperationService(IOperationRepository operationRepository, IDepartmentRepository departmentRepository, ICompanyRepository companyRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
        }

        #endregion
        #region Public
        /// <summary>
        /// Load All Operations
        /// </summary>
        public IEnumerable<Operation> LoadAll()
        {
            return operationRepository.GetAll();
        }
        /// <summary>
        /// Load Operation BaseData
        /// </summary>
        /// <returns></returns>
        public OperationBaseDataResponse LoadOperationBaseData()
        {
            return new OperationBaseDataResponse
            {
                Departments = departmentRepository.GetAll(),
                Companies =  companyRepository.GetAll(),
                DepartmentTypes =  departmentRepository.GetDepartmentsTypes()
            };
       }
        /// <summary>
        /// Search Operation
        /// </summary>
        public OperationSearchResponse SearchOperation(OperationSearchRequest searchRequest)
        {
            int rowCount;
            return new OperationSearchResponse
            {
                Operations = operationRepository.SearchOperation(searchRequest, out rowCount),
                TotalCount = rowCount
            };
        }
        /// <summary>
        /// Delete Operation
        /// </summary>
        public void DeleteOperation(Operation operationobeDeleted)
        {
            Operation dbVersion = operationRepository.Find(operationobeDeleted.OperationId);
            if (dbVersion != null) 
            { 

            operationRepository.Delete(dbVersion);
            operationRepository.SaveChanges();
            }
        }

        /// <summary>
        /// Save Operation
        /// </summary>
        public Operation SaveOperation(Operation operation)
        {

            Operation dbVersion = operationRepository.Find(operation.OperationId);
            if (dbVersion != null)
            {
                operation.RecLastUpdatedBy = operationRepository.LoggedInUserIdentity;
                operation.RecLastUpdatedDt = DateTime.Now;
                operation.RecCreatedBy = dbVersion.RecCreatedBy;
                operation.RecCreatedDt = dbVersion.RecCreatedDt;
                operation.UserDomainKey = dbVersion.UserDomainKey;
            }
            else
            {
                operation.RecCreatedBy = operation.RecLastUpdatedBy = operationRepository.LoggedInUserIdentity;
                operation.RecCreatedDt = operation.RecLastUpdatedDt = DateTime.Now;
                operation.UserDomainKey = 1;
            }
            operationRepository.Update(operation);
            operationRepository.SaveChanges();
            // To Load the proprties
            return operationRepository.GetCompanyWithDetails(operation.OperationId);
        }

        #endregion
    }
}
