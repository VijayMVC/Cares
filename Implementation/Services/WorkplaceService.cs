using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// <summary>
        /// Deletion of Operations with iD
        /// </summary>
        private void DeleteOperation(long? operationsWorkPlaceId)
        {
            if (operationsWorkPlaceId != null)
            {
                OperationsWorkPlace operationsWorkPlace = operationsWorkPlaceRepository.Find((long)operationsWorkPlaceId);
                if (operationsWorkPlace != null)
                {
                    operationsWorkPlaceRepository.Delete(operationsWorkPlace);
                }
            }
        }
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
            // Check the availability of workplace code
            if (workplaceRepository.DoesWorkPlaceCodeExists(workPlaceRequest))
                throw new CaresException(Resources.Organization.Workplace.WorkPlaceWithSameCodeExistsAlready);

            WorkPlace dbWorkPlace = workplaceRepository.Find(workPlaceRequest.WorkPlaceId);
            bool isFind = false;

            #region Edit
            if (dbWorkPlace != null)
            {
                IEnumerable<OperationsWorkPlace> dBVersionOperationsWorkPlace = operationsWorkPlaceRepository.GetWorkPlaceOperationByWorkPlaceId(dbWorkPlace.WorkPlaceId);
                // Updating object properties
                dbWorkPlace.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                dbWorkPlace.RecLastUpdatedDt = DateTime.Now;
                dbWorkPlace.WorkPlaceCode = workPlaceRequest.WorkPlaceCode;
                dbWorkPlace.WorkPlaceName = workPlaceRequest.WorkPlaceName;
                dbWorkPlace.WorkPlaceDescription = workPlaceRequest.WorkPlaceDescription;
                dbWorkPlace.WorkPlaceTypeId = workPlaceRequest.WorkPlaceTypeId;
                dbWorkPlace.WorkLocationId = workPlaceRequest.WorkLocationId;
                dbWorkPlace.ParentWorkPlaceId = workPlaceRequest.ParentWorkPlaceId;

                #region Operation already exists in DB
                // ReSharper disable once PossibleMultipleEnumeration
                if (dBVersionOperationsWorkPlace.Any())
                {
                    // check for every dBOperationsWorkPlace in DB
                    foreach (OperationsWorkPlace dBOperationsWorkPlace in dBVersionOperationsWorkPlace)
                    {
                        //If dBOperationsWorkPlace matches to any of request operation than dont delete it else delete 
                        if (workPlaceRequest.OperationsWorkPlaces != null)
                        {
                            if (workPlaceRequest.OperationsWorkPlaces.Any(reqOpp => reqOpp.OperationsWorkPlaceId == dBOperationsWorkPlace.OperationsWorkPlaceId))
                                isFind = true;
                        }
                        else
                            DeleteOperation(dBOperationsWorkPlace.OperationsWorkPlaceId);
                        if (!isFind)
                            DeleteOperation(dBOperationsWorkPlace.OperationsWorkPlaceId);
                        isFind = false;
                    }
                }
                #endregion
                #region Adding New Operation
                else
                {
                    foreach (var newOperation in workPlaceRequest.OperationsWorkPlaces)
                    {
                        newOperation.RecCreatedBy = newOperation.RecLastUpdatedBy = operationRepository.LoggedInUserIdentity;
                        newOperation.RecCreatedDt = newOperation.RecLastUpdatedDt = DateTime.Now;
                        newOperation.UserDomainKey = 1;
                        newOperation.IsActive = true;
                        newOperation.IsDeleted = false;
                        newOperation.IsPrivate = false;
                        dbWorkPlace.OperationsWorkPlaces.Add(newOperation);
                    }
                }
                #endregion
                #region Adding Operation when there are more Operation in request thatn in DB
                if (workPlaceRequest.OperationsWorkPlaces != null &&(workPlaceRequest.OperationsWorkPlaces.Count > dBVersionOperationsWorkPlace.Count()))
                    foreach (var newOperation in workPlaceRequest.OperationsWorkPlaces)
                    {
                        if (newOperation.OperationsWorkPlaceId == 0)
                        {
                            newOperation.RecCreatedBy = newOperation.RecLastUpdatedBy = operationRepository.LoggedInUserIdentity;
                            newOperation.RecCreatedDt = newOperation.RecLastUpdatedDt = DateTime.Now;
                            newOperation.UserDomainKey = 1;
                            newOperation.IsActive = true;
                            newOperation.IsDeleted = false;
                            newOperation.IsPrivate = false;
                            dbWorkPlace.OperationsWorkPlaces.Add(newOperation);
                        }
                    }

                #endregion
                workplaceRepository.Update(dbWorkPlace);
            }
            #endregion
            #region ADD
            else
            {
                workPlaceRequest.RecCreatedBy = workPlaceRequest.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                workPlaceRequest.RecCreatedDt = workPlaceRequest.RecLastUpdatedDt = DateTime.Now;
                workPlaceRequest.UserDomainKey = 1;
                if (workPlaceRequest.OperationsWorkPlaces != null)
                {
                    foreach (var operation in (workPlaceRequest.OperationsWorkPlaces))
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
            }
            #endregion
            workplaceRepository.SaveChanges();
            operationsWorkPlaceRepository.SaveChanges();


            // To Load the proprties
            WorkPlace df = workplaceRepository.GetWorkplaceWithDetails(workPlaceRequest.WorkPlaceId);
            return df;
        }

        /// <summary>
        /// Delete workplace
        /// </summary>
        public void DeleteWorkPlace(long workPlaceid)
        {
            WorkPlace dbVersion = workplaceRepository.Find(workPlaceid);
            if (!workplaceRepository.IsWorkPalceParrent(workPlaceid))
            {
                {
                    if (dbVersion != null)
                    {
                        workplaceRepository.Delete(dbVersion);
                        workplaceRepository.SaveChanges();
                    }
                    else
                        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                             "WorkPlace with Id {0} not found!", workPlaceid));
                }
            }
            else
                throw new CaresException(Resources.Organization.Workplace.WorkplaceIsAssociatedwWithOtherWorkplace);
        }
        #endregion
    }
}

