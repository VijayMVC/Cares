using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IFleetPoolRepository fleetPoolRepository;

        #endregion
        #region Constructor
        public OperationService(IOperationRepository operationRepository, IDepartmentRepository departmentRepository, ICompanyRepository companyRepository, IFleetPoolRepository fleetPoolRepository)
        {
            this.operationRepository = operationRepository;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
            this.fleetPoolRepository = fleetPoolRepository;
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
                Departments= departmentRepository.GetAll(),
                DepartmentTypes = departmentRepository.GetDepartmentsTypes()
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
        public void DeleteOperation(long operationoId)
        {
            Operation dbVersion = operationRepository.Find(operationoId);
            if (!fleetPoolRepository.IsOperationAssocisiatedWithAnyFleetPool(operationoId))
            {
                if (dbVersion != null)
                {

                    operationRepository.Delete(dbVersion);
                    operationRepository.SaveChanges();
                }
                else throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                         "Operation with Id {0} not found!", operationoId));

               
            }
            else
                throw new CaresException(Resources.Organization.Operation.OperationIsAssociatedWithFleetPool);
           
        }

        /// <summary>
        /// Save Operation
        /// </summary>
        public Operation SaveOperation(Operation operation)
        {
            Operation dbVersion = operationRepository.Find(operation.OperationId);
            if (!operationRepository.IsOperationCodeExists(operation))
            {
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
                return operationRepository.GetOperationWithDetails(operation.OperationId);
            }
            throw new CaresException(Resources.Organization.Operation.OperationWithSameCodeAlreadyExistsError);
        }
        #endregion
    }
}
