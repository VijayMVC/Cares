using System;
using System.Collections.Generic;
using System.Linq;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Workplace Service
    /// </summary>
    public class WorkplaceService : IWorkplaceService
    {
        #region Private

        // repositories 
        private readonly ICompanyRepository companyRepository;
        private readonly IWorkplaceRepository workplaceRepository;
        private readonly IWorkplaceTypeRepository workplaceTypeRepository;
        private readonly IWorkLocationRepository workLocationRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IFleetPoolRepository fleetPoolRepository;
        private readonly IOperationsWorkPlaceRepository operationsWorkPlaceRepository;
        #endregion
        #region Constructor

        /// <summary>
        /// Workplace Service Constructor
        /// </summary>
        public WorkplaceService(ICompanyRepository companyRepository, IWorkplaceRepository workplaceRepository,
            IWorkLocationRepository workLocationRepository, IWorkplaceTypeRepository workplaceTypeRepository,
            IOperationRepository operationRepository, IFleetPoolRepository fleetPoolRepository, IOperationsWorkPlaceRepository operationsWorkPlaceRepository)
        {
            this.workplaceRepository = workplaceRepository;
            this.companyRepository = companyRepository;
            this.workLocationRepository = workLocationRepository;
            this.workplaceTypeRepository = workplaceTypeRepository;
            this.operationRepository = operationRepository;
            this.fleetPoolRepository = fleetPoolRepository;
            this.operationsWorkPlaceRepository = operationsWorkPlaceRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Workplace BaseData
        /// </summary>
        public WorkplaceBaseDataResponse LoadWorkplaceBaseData()
        {
            return new WorkplaceBaseDataResponse
            {
                Companies = companyRepository.GetAll(),
                WorkLocations = workLocationRepository.GetAll(),
                WorkPlaceTypes = workplaceTypeRepository.GetAll(),
                Operations = operationRepository.GetAll(),
                Fleetpools = fleetPoolRepository.GetAll(),
                ParentWorkPlaces = workplaceRepository.GetAll()
            };
        }

        /// <summary>
        /// search work place data
        /// </summary>
        public WorkplaceSearchRequestResponse SearchWorkplace(WorkplaceSearchRequest request)
        {
            int rowCount;
            return new WorkplaceSearchRequestResponse
            {
                WorkPlaces = workplaceRepository.SearchWorkplace(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Save WorkPlace
        /// </summary>
        public WorkPlace SaveWorkPlace(WorkPlace workPlaceRequest)
        {
            WorkPlace dbVersion = workplaceRepository.Find(workPlaceRequest.WorkPlaceId);
            #region UPDATE
            if (dbVersion != null)
            {
                IEnumerable<OperationsWorkPlace> operationWorkPlaces = operationsWorkPlaceRepository.GetWorkPlaceOperationByWorkPlaceId(workPlaceRequest.WorkPlaceId);
                // Updating object properties
                dbVersion.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                dbVersion.RecLastUpdatedDt = DateTime.Now;
                dbVersion.WorkPlaceCode = workPlaceRequest.WorkPlaceCode;
                dbVersion.WorkPlaceName = workPlaceRequest.WorkPlaceName;
                dbVersion.WorkPlaceDescription = workPlaceRequest.WorkPlaceDescription;
                dbVersion.WorkPlaceTypeId = workPlaceRequest.WorkPlaceTypeId;
                dbVersion.WorkLocationId = workPlaceRequest.WorkLocationId;
                dbVersion.ParentWorkPlaceId = workPlaceRequest.ParentWorkPlaceId;
                // Checking if there is any operation work place in Workplace request object
                if (workPlaceRequest.OperationsWorkPlaces != null) 
                {
                    // for every operation in workplace request object
                    foreach (OperationsWorkPlace operation in workPlaceRequest.OperationsWorkPlaces)
                    {
                        // if there is any recored in operationWorkplace table in DB
                        if (operationWorkPlaces.Count()!=0)
                        {
                            // for every operation in dbVersionOperation object
                            foreach (OperationsWorkPlace dbVersionOperation in operationWorkPlaces)
                            {
                                // If operation is newly created with id = 0 
                                if (operation.OperationsWorkPlaceId == 0)
                                {
                                    operation.RecCreatedBy =
                                    operation.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                                    operation.RecCreatedDt = operation.RecLastUpdatedDt = DateTime.Now;
                                    operation.UserDomainKey = 1;
                                    operation.WorkPlaceId = workPlaceRequest.WorkPlaceId;
                                    operation.IsActive = true;
                                    operation.IsDeleted = false;
                                    operation.IsPrivate = false;
                                    dbVersion.OperationsWorkPlaces.Add(operation);
                                } // delete those operation objects that are not in request obj
                                else if (operation.OperationsWorkPlaceId != dbVersionOperation.OperationsWorkPlaceId)
                                {
                                    OperationsWorkPlace operationsWorkPlaces =
                                        operationsWorkPlaceRepository.Find(dbVersionOperation.OperationsWorkPlaceId);
                                    if (operationsWorkPlaces != null)
                                        operationsWorkPlaceRepository.Delete(operationsWorkPlaces);
                                }
                            } 
                        } // Add them for first time
                        else
                        {
                            operation.RecCreatedBy = operation.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                            operation.RecCreatedDt = operation.RecLastUpdatedDt = DateTime.Now;
                            operation.UserDomainKey = 1;
                            operation.WorkPlaceId = workPlaceRequest.WorkPlaceId;
                            operation.IsActive = true;
                            operation.IsDeleted = false;
                            operation.IsPrivate = false;
                            dbVersion.OperationsWorkPlaces.Add(operation);
                        }
                    }
                    operationsWorkPlaceRepository.SaveChanges();
                    workplaceRepository.Update(dbVersion);
                    workplaceRepository.SaveChanges();
                }   // request object does not contain any operation , so delete all associated operation entities 
                else
                {
                    foreach (OperationsWorkPlace dbVersionOperation in operationWorkPlaces)
                    {
                        OperationsWorkPlace operationsWorkPlaces = operationsWorkPlaceRepository.Find(dbVersionOperation.OperationsWorkPlaceId);
                        if (operationsWorkPlaces != null)
                            operationsWorkPlaceRepository.Delete(operationsWorkPlaces);
                    }
                    operationsWorkPlaceRepository.SaveChanges();
                }
            }
            #endregion
            #region ADD 
                 // add new  record and associated operations
            else
            {
                workPlaceRequest.RecCreatedBy = workPlaceRequest.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                workPlaceRequest.RecCreatedDt = workPlaceRequest.RecLastUpdatedDt = DateTime.Now;
                workPlaceRequest.UserDomainKey = 1;
                if (workPlaceRequest.OperationsWorkPlaces != null)
                {
                    foreach (var operation in workPlaceRequest.OperationsWorkPlaces)
                    {
                        operation.RecCreatedBy = operation.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                        operation.RecCreatedDt = operation.RecLastUpdatedDt = DateTime.Now;
                        operation.UserDomainKey = 1;
                        operation.IsActive = true;
                        operation.IsDeleted = false;
                        operation.IsPrivate = false;
                    }
                }
                workplaceRepository.Add(workPlaceRequest);
                workplaceRepository.SaveChanges();
            }
            #endregion
            // To Load the proprties
            WorkPlace df = workplaceRepository.GetWorkplaceWithDetails(workPlaceRequest.WorkPlaceId);
            return df;
        }

        /// <summary>
        /// Delete workplace
        /// </summary>
        public void DeleteWorkPlace(WorkPlace workPlace)
        {
            WorkPlace dbVersion = workplaceRepository.Find(workPlace.WorkPlaceId);
            {
                if (dbVersion != null)
                {
                    workplaceRepository.Delete(dbVersion);
                    workplaceRepository.SaveChanges();
                }
            }
        }
        #endregion
    }
}

