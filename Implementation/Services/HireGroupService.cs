using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Hire Group Service
    /// </summary>
    public class HireGroupService : IHireGroupService
    {
        #region Private
        private readonly IHireGroupRepository hireGroupRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IVehicleCategoryRepository vehicleCategoryRepository;
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IHireGroupUpGradeRepository hireGroupUpGradeRepository;
        #endregion
        #region Constructors
        public HireGroupService(IHireGroupRepository hireGroupRepository, ICompanyRepository companyRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository, IHireGroupDetailRepository hireGroupDetailRepository,
            IHireGroupUpGradeRepository hireGroupUpGradeRepository)
        {
            if (hireGroupDetailRepository == null)
            {
                throw new ArgumentNullException("hireGroupDetailRepository");
            }
            this.hireGroupRepository = hireGroupRepository;
            this.companyRepository = companyRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.hireGroupUpGradeRepository = hireGroupUpGradeRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load Hire Group Base data
        /// </summary>
        /// <returns></returns>
        public HireGroupBaseResponse LoadBaseData()
        {
            IEnumerable<Company> companies = companyRepository.GetAll();
            IEnumerable<HireGroup> parentHireGroups = hireGroupRepository.GetParentHireGroups();
            IEnumerable<VehicleCategory> vehicleCategories = vehicleCategoryRepository.GetAll();
            IEnumerable<VehicleMake> vehicleMakes = vehicleMakeRepository.GetAll();
            IEnumerable<VehicleModel> vehicleModels = vehicleModelRepository.GetAll();
            //exlude parent hire group
            IEnumerable<HireGroup> hireGroups = hireGroupRepository.GetHireGroupList();
            return new HireGroupBaseResponse
            {
                Companies = companies,
                ParentHireGroups = parentHireGroups,
                VehicleCategories = vehicleCategories,
                VehicleMakes = vehicleMakes,
                VehicleModels = vehicleModels,
                HireGroups = hireGroups
            };
        }

        /// <summary>
        /// Get Hire Groups By Code, Vehicle Make / Category / Model / Model Year
        /// </summary>
        public IEnumerable<HireGroupDetail> GetByCodeAndVehicleInfo(string searchText)
        {
            return hireGroupDetailRepository.GetByCodeAndVehicleInfo(searchText);
        }

        /// <summary>
        /// Load tariff type, based on search filters
        /// </summary>
        /// <param name="hireGroupSearchRequest"></param>
        /// <returns></returns>
        public HireGroupSearchResponse LoadHireGroups(HireGroupSearchRequest hireGroupSearchRequest)
        {
            return hireGroupRepository.GetHireGroups(hireGroupSearchRequest);
        }
        /// <summary>
        /// Find Hire Group by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HireGroup FindById(long id)
        {
            return hireGroupRepository.Find(id);
        }
        /// <summary>
        /// Delete Hire Group
        /// </summary>
        /// <param name="instance"></param>
        public void DeleteHireGroup(HireGroup instance)
        {
            hireGroupRepository.Delete(instance);
            hireGroupRepository.SaveChanges();

        }
        /// <summary>
        /// Add Hire Group
        /// </summary>
        /// <param name="request"></param>
        public HireGroup AddHireGroup(HireGroupAddRequest request)
        {
            request.HireGroup.RecCreatedDt = System.DateTime.Now;
            request.HireGroup.RecLastUpdatedDt = System.DateTime.Now;
            request.HireGroup.UserDomainKey = hireGroupRepository.UserDomainKey;
            request.HireGroup.RecCreatedBy = "Cares";
            request.HireGroup.RowVersion = 0;
            request.HireGroup.RecLastUpdatedBy = "Cares";
            request.HireGroup.IsReadOnly = false;
            request.HireGroup.IsDeleted = false;
            request.HireGroup.IsPrivate = false;
            request.HireGroup.IsActive = false;
            hireGroupRepository.Add(request.HireGroup);
            hireGroupRepository.SaveChanges();
            if (request.HireGroupDetails != null)
            {
                foreach (var hireGroupDetail in request.HireGroupDetails)
                {
                    hireGroupDetail.RecCreatedDt = DateTime.Now;
                    hireGroupDetail.RecLastUpdatedDt = DateTime.Now;
                    hireGroupDetail.UserDomainKey = hireGroupRepository.UserDomainKey;
                    hireGroupDetail.RecCreatedBy = "Cares";
                    hireGroupDetail.RowVersion = 0;
                    hireGroupDetail.RecLastUpdatedBy = "Cares";
                    hireGroupDetail.IsReadOnly = false;
                    hireGroupDetail.IsDeleted = false;
                    hireGroupDetail.IsPrivate = false;
                    hireGroupDetail.IsActive = false;
                    hireGroupDetail.HireGroupId = request.HireGroup.HireGroupId;
                    hireGroupDetailRepository.Add(hireGroupDetail);
                    hireGroupDetailRepository.SaveChanges();
                }
            }
            if (request.HireGroupUpGrades != null)
            {
                foreach (var hireGroupUpGrade in request.HireGroupUpGrades)
                {
                    hireGroupUpGrade.RecCreatedDt = DateTime.Now;
                    hireGroupUpGrade.RecLastUpdatedDt = DateTime.Now;
                    hireGroupUpGrade.UserDomainKey = hireGroupRepository.UserDomainKey;
                    hireGroupUpGrade.RecCreatedBy = "Cares";
                    hireGroupUpGrade.RowVersion = 0;
                    hireGroupUpGrade.RecLastUpdatedBy = "Cares";
                    hireGroupUpGrade.IsReadOnly = false;
                    hireGroupUpGrade.IsDeleted = false;
                    hireGroupUpGrade.IsPrivate = false;
                    hireGroupUpGrade.IsActive = false;
                    hireGroupUpGrade.HireGroupId = request.HireGroup.HireGroupId;
                    hireGroupUpGrade.AllowedHireGroupId = hireGroupUpGrade.AllowedHireGroupId;
                    hireGroupUpGradeRepository.Add(hireGroupUpGrade);
                    hireGroupUpGradeRepository.SaveChanges();
                }
            }
            var hirGroup = hireGroupRepository.Find(request.HireGroup.HireGroupId);
            hireGroupRepository.LoadDependencies(hirGroup);
            return hirGroup;
        }
        /// <summary>
        /// Update Hire Group
        /// </summary>
        /// <param name="hireGroup"></param>
        public HireGroup UpdateHireGroup(HireGroupAddRequest hireGroup)
        {
            HireGroup hireGroupDbVersion = hireGroupRepository.Find(hireGroup.HireGroup.HireGroupId);

            //set child (Hire Group detail list)
            #region Hire Group Detial List List
            //add new Hire group Detail items
            if (hireGroup.HireGroupDetails != null)
            {
                foreach (HireGroupDetail hireGroupDetail in hireGroup.HireGroupDetails)
                {
                    if (
                        hireGroupDbVersion.HireGroupDetails.All(
                            x => x.HireGroupDetailId != hireGroupDetail.HireGroupDetailId) ||
                        hireGroupDetail.HireGroupDetailId == 0)
                    {
                        // set properties
                        hireGroupDetail.RecCreatedDt = DateTime.Now;
                        hireGroupDetail.RecLastUpdatedDt = DateTime.Now;
                        hireGroupDetail.UserDomainKey = hireGroupRepository.UserDomainKey;
                        hireGroupDetail.RecCreatedBy = "Cares";
                        hireGroupDetail.RowVersion = 0;
                        hireGroupDetail.RecLastUpdatedBy = "Cares";
                        hireGroupDetail.IsReadOnly = false;
                        hireGroupDetail.IsDeleted = false;
                        hireGroupDetail.IsPrivate = false;
                        hireGroupDetail.IsActive = false;
                        hireGroupDetail.HireGroupId = hireGroup.HireGroup.HireGroupId;
                        hireGroupDbVersion.HireGroupDetails.Add(hireGroupDetail);
                    }
                }
            }
            //find missing Hire Group Detail items
            List<HireGroupDetail> missingHireGroupDetailItems = new List<HireGroupDetail>();
            foreach (HireGroupDetail dbversionHireGroupDetailItem in hireGroupDbVersion.HireGroupDetails)
            {
                if (hireGroup.HireGroupDetails.All(x => x.HireGroupDetailId != dbversionHireGroupDetailItem.HireGroupDetailId))
                {
                    missingHireGroupDetailItems.Add(dbversionHireGroupDetailItem);
                }
            }
            //remove missing Hire Group Detail  items
            foreach (HireGroupDetail missingHireGroupDetail in missingHireGroupDetailItems)
            {
                HireGroupDetail dbVersionHireGroupDetailItem = hireGroupDbVersion.HireGroupDetails.First(x => x.HireGroupDetailId == missingHireGroupDetail.HireGroupDetailId);
                if (dbVersionHireGroupDetailItem.HireGroupDetailId > 0)
                {
                    hireGroupDbVersion.HireGroupDetails.Remove(dbVersionHireGroupDetailItem);
                    hireGroupDetailRepository.Delete(dbVersionHireGroupDetailItem);
                }
            }
            #endregion
            //set child (Hire Group Up Grade list)
            #region Hire Group Up Grade list
            //add new address items
            if (hireGroup.HireGroupUpGrades != null)
            {
                foreach (HireGroupUpGrade hireGroupUpGrade in hireGroup.HireGroupUpGrades)
                {
                    if (hireGroupDbVersion.HireGroupUpGradList.All(x => x.HireGroupUpGradeId != hireGroupUpGrade.HireGroupUpGradeId) || hireGroupUpGrade.HireGroupUpGradeId == 0)
                    {
                        // set properties
                        hireGroupUpGrade.RecCreatedDt = DateTime.Now;
                        hireGroupUpGrade.RecLastUpdatedDt = DateTime.Now;
                        hireGroupUpGrade.UserDomainKey = hireGroupRepository.UserDomainKey;
                        hireGroupUpGrade.RecCreatedBy = "Cares";
                        hireGroupUpGrade.RowVersion = 0;
                        hireGroupUpGrade.RecLastUpdatedBy = "Cares";
                        hireGroupUpGrade.IsReadOnly = false;
                        hireGroupUpGrade.IsDeleted = false;
                        hireGroupUpGrade.IsPrivate = false;
                        hireGroupUpGrade.IsActive = false;
                        hireGroupUpGrade.HireGroupId = hireGroup.HireGroup.HireGroupId;
                        hireGroupUpGrade.AllowedHireGroupId = hireGroupUpGrade.AllowedHireGroupId;
                        hireGroupDbVersion.HireGroupUpGradList.Add(hireGroupUpGrade);
                    }
                }
            }
            //find missing Hire Group Up Garde items
            List<HireGroupUpGrade> missingHireGroupUpGradeItems = new List<HireGroupUpGrade>();
            foreach (HireGroupUpGrade dbversionHireGroupUpGradeItem in hireGroupDbVersion.HireGroupUpGradList)
            {
                if (hireGroup.HireGroupUpGrades.All(x => x.HireGroupUpGradeId != dbversionHireGroupUpGradeItem.HireGroupUpGradeId))
                {
                    missingHireGroupUpGradeItems.Add(dbversionHireGroupUpGradeItem);
                }
            }
            //remove missing Hire Group Up Grade items
            foreach (HireGroupUpGrade missingHireGroupUpGrade in missingHireGroupUpGradeItems)
            {
                HireGroupUpGrade dbVersionHireGroupDetailItem = hireGroupDbVersion.HireGroupUpGradList.First(x => x.HireGroupUpGradeId == missingHireGroupUpGrade.HireGroupUpGradeId);
                if (dbVersionHireGroupDetailItem.HireGroupUpGradeId > 0)
                {
                    hireGroupDbVersion.HireGroupUpGradList.Remove(dbVersionHireGroupDetailItem);
                    hireGroupUpGradeRepository.Delete(dbVersionHireGroupDetailItem);
                }
            }
            #endregion

            hireGroupRepository.SaveChanges();
            var hirGroup = hireGroupRepository.Find(hireGroup.HireGroup.HireGroupId);
            hireGroupRepository.LoadDependencies(hirGroup);
            return hirGroup;
        }
        /// <summary>
        /// Get Hire Group Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HireGroupDataDetailResponse FindHireGroupId(long id)
        {
            return new HireGroupDataDetailResponse
                   {
                       HireGroupDetails = hireGroupDetailRepository.GetHireGroupDetailByHireGroupId(id),
                       HireGroupUpGrades = hireGroupUpGradeRepository.FindByHireGroupId(id)
                   };
        }
        #endregion


    }
}
