
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Work Place Type Service
    /// </summary>
    public class WorkPlaceTypeService : IWorkplaceTypeService
    {

        #region Private

        /// <summary>
        /// Private members
        /// </summary>
        private readonly IWorkplaceTypeRepository workplaceTypeRepository;

        #endregion
        #region Constructor

        /// <summary>
        ///  Constructor
        /// </summary>
        public WorkPlaceTypeService(IWorkplaceTypeRepository workplaceTypeRepository)
        {
            this.workplaceTypeRepository = workplaceTypeRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Search Workplace Type
        /// </summary>
        public WorkPlaceTypeSearchRequestResponse SearchWorkplaceType(WorkplaceTypeSearchRequest request)
        {
            int rowCount;
            return new WorkPlaceTypeSearchRequestResponse
            {
                WorkPlaceTypes = workplaceTypeRepository.SearchWorkplaceType(request, out rowCount),
                TotalCount = rowCount
            };
        }


        /// <summary>
        /// Delete Workplace Type
        /// </summary>
        public void DeleteWorkPlaceType(long workPlaceTypeId)
        {
            WorkPlaceType dbversion = workplaceTypeRepository.Find(workPlaceTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Workplace Type with Id {0} not found!", workPlaceTypeId));
            }
            workplaceTypeRepository.Delete(dbversion);
            workplaceTypeRepository.SaveChanges();
        }



        /// <summary>
        /// Add / Update WorkPlaceType
        /// </summary>
        public WorkPlaceType AddUpdateWorkPlaceType(WorkPlaceType workPlaceType)
        {
            WorkPlaceType dbVersion = workplaceTypeRepository.Find(workPlaceType.WorkPlaceTypeId);
            if (!workplaceTypeRepository.IsWorkPlaceTypeCodeExists(workPlaceType))
            {
                if (dbVersion != null)
                {
                    dbVersion.RecLastUpdatedBy = workplaceTypeRepository.LoggedInUserIdentity;
                    dbVersion.RecLastUpdatedDt = DateTime.Now;
                    dbVersion.RowVersion = dbVersion.RowVersion + 1;
                    dbVersion.WorkPlaceTypeCode = workPlaceType.WorkPlaceTypeCode;
                    dbVersion.WorkPlaceTypeName = workPlaceType.WorkPlaceNature;
                    dbVersion.WorkPlaceTypeDescription = workPlaceType.WorkPlaceTypeDescription;
                    dbVersion.WorkPlaceNature = workPlaceType.WorkPlaceNature;
                    workplaceTypeRepository.Update(dbVersion);
                }
                else
                {
                    workPlaceType.RecCreatedBy =
                    workPlaceType.RecLastUpdatedBy = workplaceTypeRepository.LoggedInUserIdentity;
                    workPlaceType.RecCreatedDt = workPlaceType.RecLastUpdatedDt = DateTime.Now;
                    workPlaceType.RowVersion = 0;
                    workPlaceType.UserDomainKey = 1;
                    workplaceTypeRepository.Add(workPlaceType);
                }
               
                workplaceTypeRepository.SaveChanges();
                // To Load the proprties
                return workplaceTypeRepository.Find(workPlaceType.WorkPlaceTypeId);
            }
            throw new CaresException(Resources.Organization.WorkPlaceType.WorkPlaceTypeCodeAlreadyExistsError);
        }
        #endregion
    }
}

