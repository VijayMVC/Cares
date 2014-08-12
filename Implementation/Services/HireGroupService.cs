using System.Collections.Generic;
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
        #endregion
        #region Constructors
        public HireGroupService(IHireGroupRepository hireGroupRepository, ICompanyRepository companyRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository, IHireGroupDetailRepository hireGroupDetailRepository)
        {
            this.hireGroupRepository = hireGroupRepository;
            this.companyRepository = companyRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
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
        public IEnumerable<HireGroup> GetByCodeAndVehicleInfo(string searchText)
        {
            return hireGroupRepository.GetByCodeAndVehicleInfo(searchText);
        }

        /// <summary>
        /// Load tarrif type, based on search filters
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
        public void AddHireGroup(HireGroupAddRequest request)
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
            foreach (var hireGroupDetail in request.HireGroupDetails)
            {
                hireGroupDetail.HireGroupId = request.HireGroup.HireGroupId;
                hireGroupDetailRepository.Add(hireGroupDetail);
                hireGroupDetailRepository.SaveChanges();
            }
        }
        /// <summary>
        /// Update Hire Group
        /// </summary>
        /// <param name="request"></param>
        public void UpdateHireGroup(HireGroupAddRequest request)
        {
            hireGroupRepository.Update(request.HireGroup);
            hireGroupRepository.SaveChanges();
            IEnumerable<HireGroupDetail> hireGroupDetailsDbVersion = hireGroupDetailRepository.GetHireGroupDetailByHireGroupId(request.HireGroup.HireGroupId);
            var updatedItems = new List<long>();

            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var hireGroupDetail in request.HireGroupDetails)
            {
                //check whether item is updated or not in loop
                int addCheck = 0;
                foreach (var groupDetail in hireGroupDetailsDbVersion)
                {
                    if (hireGroupDetail.HireGroupDetailId == groupDetail.HireGroupDetailId)
                    {
                        hireGroupDetail.HireGroupId = request.HireGroup.HireGroupId;
                        hireGroupDetailRepository.Update(hireGroupDetail);
                        hireGroupDetailRepository.SaveChanges();
                        updatedItems.Add(groupDetail.HireGroupDetailId);
                        addCheck = 1;
                    }

                }
                if (addCheck == 0)
                {
                    hireGroupDetail.HireGroupId = request.HireGroup.HireGroupId;
                    hireGroupDetailRepository.Add(hireGroupDetail);
                    hireGroupDetailRepository.SaveChanges();
                }
            }
            //delete hire groups
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var groupDetail in hireGroupDetailsDbVersion)
            {
                int delete = 0;
                for (int i = 0; i < updatedItems.Count; i--)
                {
                    if (groupDetail.HireGroupDetailId == updatedItems[i])
                    {
                        delete = 1;
                    }
                }
                if (delete == 0)
                {
                    hireGroupDetailRepository.Delete(groupDetail);
                    hireGroupDetailRepository.SaveChanges();
                }

            }
        }
        #endregion


    }
}
