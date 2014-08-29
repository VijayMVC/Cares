using System;
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

        private readonly ICompanyRepository companyRepository;
        private readonly IWorkplaceRepository workplaceRepository;
        private readonly IWorkplaceTypeRepository workplaceTypeRepository;
        private readonly IWorkLocationRepository workLocationRepository;

        #endregion

        #region Constructor

        public WorkplaceService(ICompanyRepository companyRepository, IWorkplaceRepository workplaceRepository,
            IWorkLocationRepository workLocationRepository, IWorkplaceTypeRepository workplaceTypeRepository)
        {
            this.workplaceRepository = workplaceRepository;
            this.companyRepository = companyRepository;
            this.workLocationRepository = workLocationRepository;
            this.workplaceTypeRepository = workplaceTypeRepository;
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
                WorkPlaceTypes = workplaceTypeRepository.GetAll()
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
        public WorkPlace SaveWorkPlace(WorkPlace workPlace)
        {
            WorkPlace dbVersion = workplaceRepository.Find(workPlace.WorkPlaceId);
            {
                if (dbVersion != null)
                {
                    workPlace.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                    workPlace.RecLastUpdatedDt = DateTime.Now;
                    workPlace.RecCreatedBy = dbVersion.RecCreatedBy;
                    workPlace.RecCreatedDt = dbVersion.RecCreatedDt;
                    workPlace.UserDomainKey = dbVersion.UserDomainKey;
                  //  workPlace.WorkLocation.CompanyId = workPlace.CompanyId;
                }
                else
                {
                    workPlace.RecCreatedBy = workPlace.RecLastUpdatedBy = workplaceRepository.LoggedInUserIdentity;
                    workPlace.RecCreatedDt = workPlace.RecLastUpdatedDt = DateTime.Now;
                    workPlace.UserDomainKey = 1;
                }
                workplaceRepository.Update(workPlace);
                workplaceRepository.SaveChanges();
                // To Load the proprties
                WorkPlace df= workplaceRepository.GetWorkplaceWithDetails(workPlace.WorkPlaceId);
                return df;
            }

            #endregion
        }
    }
}
