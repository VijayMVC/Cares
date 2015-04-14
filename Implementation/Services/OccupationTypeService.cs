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
    /// Occupation Type Service
    /// </summary>
    public class OccupationTypeService : IOccupationTypeService
    {
        #region Private
        private readonly IOccupationTypeRepository occupationTypeRepository;
        private readonly IBusinessPartnerIndividualRepository businessPartnerIndividualRepository;

        /// <summary>
        /// Check occupation Type association with other entites before deletion
        /// </summary>
        private void CheckOccupationTypeAssociations(long occupationTypeId)
        {
            //  Business Partner Individual -Occupation Type association checking
            if (businessPartnerIndividualRepository.IsOccupationTypeAssociatedWithBusinessPartnerIndividual(occupationTypeId))
                throw new CaresException(Resources.BusinessPartner.OccupationType.OccupationTypeIsAssociatedWithBusinessPartnerIndividual);
        }


        /// <summary>
        /// Set Occupation Type Properties while adding new instance
        /// </summary>
        private void SetOccupationTypeProperties(OccupationType occupationTypeRequest, OccupationType dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = occupationTypeRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = occupationTypeRepository.UserDomainKey;
            dbVersion.OccupationTypeCode = occupationTypeRequest.OccupationTypeCode;
            dbVersion.OccupationTypeName = occupationTypeRequest.OccupationTypeName;
            dbVersion.OccupationTypeDescription = occupationTypeRequest.OccupationTypeDescription;
        }

        /// <summary>
        /// Update OccupationType Properties while updating the instance
        /// </summary>
        private void UpdateOccupationTypeProperties(OccupationType occupationTypeRequest, OccupationType dbVersion)
        {
            dbVersion.RecLastUpdatedBy = occupationTypeRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.OccupationTypeCode = occupationTypeRequest.OccupationTypeCode;
            dbVersion.OccupationTypeName = occupationTypeRequest.OccupationTypeName;
            dbVersion.OccupationTypeDescription = occupationTypeRequest.OccupationTypeDescription;
        }
        #endregion
        #region Constructor
        public OccupationTypeService(IOccupationTypeRepository occupationTypeRepository, IBusinessPartnerIndividualRepository businessPartnerIndividualRepository)
        {
            this.occupationTypeRepository = occupationTypeRepository;
            this.businessPartnerIndividualRepository = businessPartnerIndividualRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Occupation Types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OccupationType> LoadAll()
        {
            return occupationTypeRepository.GetAll();
        }

        /// <summary>
        /// Search Occupation Type
        /// </summary>
        public OccupationTypeSearchRequestResponse SearchOccupationType(OccupationTypeSearchRequest request)
        {
            int rowCount;
            return new OccupationTypeSearchRequestResponse
            {
                OccupationTypes = occupationTypeRepository.SearchOccupationType(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Occupation Type
        /// </summary>
        public void DeleteOccupationType(long occupationTypeId)
        {
            OccupationType dbversion = occupationTypeRepository.Find(occupationTypeId);
            CheckOccupationTypeAssociations(occupationTypeId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BusinessPartner.OccupationType.OccupationTypeNotFound));
            }
            occupationTypeRepository.Delete(dbversion);
            occupationTypeRepository.SaveChanges(); 
        }

        /// <summary>
        /// Add / Update Occupation Type
        /// </summary>
        public OccupationType AddUpdateOccupationType(OccupationType occupationType)
        {
            OccupationType dbVersion = occupationTypeRepository.Find(occupationType.OccupationTypeId);

            if (occupationTypeRepository.OccupationTypeCodeDuplicationCheck(occupationType))
                throw new CaresException(Resources.BusinessPartner.OccupationType.OccupationTypeCodeDuplicationCheck);

            if (dbVersion != null)
            {
                UpdateOccupationTypeProperties(occupationType, dbVersion);
                occupationTypeRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new OccupationType();
                SetOccupationTypeProperties(occupationType, dbVersion);
                occupationTypeRepository.Add(dbVersion);
            }
            occupationTypeRepository.SaveChanges();
            // To Load the proprties
            return occupationTypeRepository.Find(dbVersion.OccupationTypeId);
        }
        #endregion
    }
}
