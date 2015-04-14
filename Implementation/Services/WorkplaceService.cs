using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.Commons;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
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
        /// Set WorkPlace Properties
        /// </summary>
        private void SetNewlyAddedWorkPlaceProperties(WorkPlace workPlaceRequest, WorkPlace dbWorkPlace)
        {
            dbWorkPlace.WorkPlaceCode = workPlaceRequest.WorkPlaceCode;
            dbWorkPlace.WorkPlaceName = workPlaceRequest.WorkPlaceName;
            dbWorkPlace.WorkPlaceDescription = workPlaceRequest.WorkPlaceDescription;
            dbWorkPlace.WorkPlaceTypeId = workPlaceRequest.WorkPlaceTypeId;
            dbWorkPlace.WorkLocationId = workPlaceRequest.WorkLocationId;
            dbWorkPlace.ParentWorkPlaceId = workPlaceRequest.ParentWorkPlaceId;
            dbWorkPlace.RecCreatedBy = dbWorkPlace.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
            dbWorkPlace.RecCreatedDt = DateTime.Now;
            dbWorkPlace.RecLastUpdatedDt = DateTime.Now;
            dbWorkPlace.UserDomainKey = operationsWorkPlaceRepository.UserDomainKey;
        }
        /// <summary>
        /// Insert new location to Loaction list
        /// </summary>
        private void AddNewLocationToOperationWorkplaceList(OperationsWorkPlace toBeAdded, ICollection<OperationsWorkPlace> locations)
        {
            OperationsWorkPlace newLocation = operationsWorkPlaceRepository.Create();
            newLocation.IsActive = true;
            newLocation.IsDeleted = newLocation.IsPrivate = newLocation.IsReadOnly = false;
            newLocation.RecCreatedBy = newLocation.RecLastUpdatedBy = operationsWorkPlaceRepository.LoggedInUserIdentity;
            newLocation.RecCreatedDt = newLocation.RecLastUpdatedDt = DateTime.Now;
            newLocation.UserDomainKey = operationsWorkPlaceRepository.UserDomainKey;
            newLocation.RowVersion = 0;
            newLocation.LocationCode = toBeAdded.LocationCode;
            newLocation.LocationName = toBeAdded.LocationName;
            newLocation.OperationId = toBeAdded.OperationId;
            newLocation.FleetPoolId = toBeAdded.FleetPoolId;
            newLocation.CostCenter = toBeAdded.CostCenter;
            newLocation.WorkPlaceId = toBeAdded.WorkPlaceId;
            locations.Add(newLocation);
        }
        /// <summary>
        /// Update Work Place Properties in Updation case
        /// </summary>
        private void UpdateWorkPlaceProperties(WorkPlace workPlaceRequest, WorkPlace dbWorkPlace)
        {
            dbWorkPlace.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
            dbWorkPlace.RecLastUpdatedDt = DateTime.Now;
            dbWorkPlace.RowVersion = dbWorkPlace.RowVersion + 1;
            dbWorkPlace.WorkPlaceCode = workPlaceRequest.WorkPlaceCode;
            dbWorkPlace.WorkPlaceName = workPlaceRequest.WorkPlaceName;
            dbWorkPlace.WorkPlaceDescription = workPlaceRequest.WorkPlaceDescription;
            dbWorkPlace.WorkPlaceTypeId = workPlaceRequest.WorkPlaceTypeId;
            dbWorkPlace.WorkLocationId = workPlaceRequest.WorkLocationId;
            dbWorkPlace.ParentWorkPlaceId = workPlaceRequest.ParentWorkPlaceId;
        }
        /// <summary>
        /// Validate Workplace and its associated locations - 
        /// </summary>
        private void ValidateWorkplace(WorkPlace workPlaceRequest)
        {
            if (workplaceRepository.WorkplaceCodeDuplicated(workPlaceRequest))
            {
                throw new CaresException(Resources.Organization.Workplace.WorkPlaceWithSameCodeExistsAlready);
            }

            if (workPlaceRequest.OperationsWorkPlaces != null && workPlaceRequest.OperationsWorkPlaces.Any())
            {
                if (workPlaceRequest.OperationsWorkPlaces.GroupBy(opwp => opwp.LocationCode).Any(group => group.Count() > 1))
                {
                    OperationsWorkPlace duplicatedLocationCode = workPlaceRequest.OperationsWorkPlaces.GroupBy(opwp => opwp.LocationCode)
                            .Where(group => group.Count() > 1).Select(operationsWorkPlaces => operationsWorkPlaces.FirstOrDefault()).FirstOrDefault();
                    string duplicatedCode = string.Empty;
                    if (duplicatedLocationCode != null)
                    {
                        duplicatedCode = duplicatedLocationCode.LocationCode;
                    }
                    throw new CaresException(string.Format(CultureInfo.InvariantCulture, Resources.Organization.Workplace.LocationCodeDuplicated, duplicatedCode));
                }

                IList<OperationsWorkPlace> existingWorkplaces = operationsWorkPlaceRepository.GetAll().Where(location => location.WorkPlaceId != workPlaceRequest.WorkPlaceId).ToList();

                foreach (OperationsWorkPlace currentWorkPlaceLocation in workPlaceRequest.OperationsWorkPlaces)
                {
                    if (existingWorkplaces.Any(otherWorhplace => otherWorhplace.LocationCode == currentWorkPlaceLocation.LocationCode))
                    {
                        throw new CaresException(string.Format(CultureInfo.InvariantCulture,
                            Resources.Organization.Workplace.LocationCodeDuplicated, currentWorkPlaceLocation.LocationCode));
                    }
                }
            }
            if (workPlaceRequest.OperationsWorkPlaces != null && workPlaceRequest.OperationsWorkPlaces.Any(opwp => opwp.OperationsWorkPlaceId == 0))// if a new branch is to be added                
            {
                int numberOfExistedworkplacesByDomainKey = operationsWorkPlaceRepository.GetCountofBranchesInOtherWorkplaces(workPlaceRequest.WorkPlaceId);
                DomainLicenseDetailClaim licenseDetails = ClaimHelper.GetDeserializedClaims<DomainLicenseDetailClaim>(CaresUserClaims.DomainLicenseDetail).FirstOrDefault();
                if (licenseDetails == null)
                {
                    throw new InvalidOperationException(Resources.Organization.Workplace.NoDomainLicenseDetailClaim);
                }
                if (licenseDetails.Branches <= (numberOfExistedworkplacesByDomainKey + workPlaceRequest.OperationsWorkPlaces.Count))
                {
                    throw new CaresException(Resources.Organization.Workplace.ExceedingDomainLimitForWpError);
                }
            }
        }
        /// <summary>
        /// Add workplace and all associated locations
        /// </summary>
        private WorkPlace AddWorkplace(WorkPlace workPlaceRequest, WorkPlace dbWorkPlace)
        {
            SetNewlyAddedWorkPlaceProperties(workPlaceRequest, dbWorkPlace);
            if (workPlaceRequest.OperationsWorkPlaces != null && workPlaceRequest.OperationsWorkPlaces.Any())
            {
                foreach (OperationsWorkPlace toBeAddedLocation in workPlaceRequest.OperationsWorkPlaces)
                {
                    AddNewLocationToOperationWorkplaceList(toBeAddedLocation, dbWorkPlace.OperationsWorkPlaces);
                }
            }
            workplaceRepository.Add(dbWorkPlace);
            return dbWorkPlace;
        }
        /// <summary>
        /// Update workplace in the database - updates its locations as well
        /// </summary>
        private void UpdateWorkplace(WorkPlace workPlaceRequest, WorkPlace dbWorkPlace)
        {
            // Updating Workplace Properties
            UpdateWorkPlaceProperties(workPlaceRequest, dbWorkPlace);
            //Remove existing items that are removed in the request
            if (dbWorkPlace.OperationsWorkPlaces != null && dbWorkPlace.OperationsWorkPlaces.Any())
            {
                List<OperationsWorkPlace> dbOperationWorkplaces = dbWorkPlace.OperationsWorkPlaces.ToList();
                if (workPlaceRequest.OperationsWorkPlaces == null)
                {
                    workPlaceRequest.OperationsWorkPlaces = new List<OperationsWorkPlace>();
                }
                List<OperationsWorkPlace> toBeRemovedOperationsWorkPlaces = dbOperationWorkplaces.Where(
                    i => workPlaceRequest.OperationsWorkPlaces.All(j => i.OperationsWorkPlaceId != j.OperationsWorkPlaceId)).ToList();
                foreach (OperationsWorkPlace currentRemoveItem in toBeRemovedOperationsWorkPlaces.ToList())
                {
                    DeleteLocationByLocationId(currentRemoveItem.OperationsWorkPlaceId);
                    //dbWorkPlace.OperationsWorkPlaces.Remove(
                    //    dbWorkPlace.OperationsWorkPlaces.FirstOrDefault(
                    //        current => current.OperationsWorkPlaceId == currentRemoveItem.OperationsWorkPlaceId));
                }
            }
            if (workPlaceRequest.OperationsWorkPlaces.Any())
            {
                //Insert newly added locations
                foreach (
                    OperationsWorkPlace toBeAddedLocation in
                        workPlaceRequest.OperationsWorkPlaces.Where(it => it.OperationsWorkPlaceId == 0))
                {
                    AddNewLocationToOperationWorkplaceList(toBeAddedLocation, dbWorkPlace.OperationsWorkPlaces);
                }
            }
            workplaceRepository.Update(dbWorkPlace);
        }
        /// <summary>
        /// Deletes Operations workplace by OperationWorkplaceId
        /// </summary>
        private void DeleteLocationByLocationId(long opertionWorkplaceId)
        {
            var location = operationsWorkPlaceRepository.Find(opertionWorkplaceId);
            operationsWorkPlaceRepository.Delete(location);
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
        /// Saves WorkPlace
        /// </summary>
        public WorkPlace SaveWorkPlace(WorkPlace workPlaceRequest)
        {            
            ValidateWorkplace(workPlaceRequest);
            WorkPlace dbWorkPlace = workplaceRepository.Find(workPlaceRequest.WorkPlaceId);
            if (dbWorkPlace != null)
            {                
                UpdateWorkplace(workPlaceRequest, dbWorkPlace);
            }
            else
            {
                dbWorkPlace = workplaceRepository.Create();
                dbWorkPlace = AddWorkplace(workPlaceRequest, dbWorkPlace);
            }
            workplaceRepository.SaveChanges();
            
            return  workplaceRepository.GetWorkplaceWithDetails(dbWorkPlace.WorkPlaceId);
        }

        /// <summary>
        /// Deletes workplace
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
                        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.Organization.Workplace.WorkPlaceNotFoundInDatabase));
                }
            }
            else
                throw new CaresException(Resources.Organization.Workplace.WorkplaceIsAssociatedwWithOtherWorkplace);
        }
        #endregion
    }
}

