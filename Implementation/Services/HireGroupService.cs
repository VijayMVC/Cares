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
            IHireGroupUpGradeRepository hireGroupUpGradeRepository){
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
                    hireGroupDetail.RecCreatedDt = System.DateTime.Now;
                    hireGroupDetail.RecLastUpdatedDt = System.DateTime.Now;
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
                    hireGroupUpGrade.RecCreatedDt = System.DateTime.Now;
                    hireGroupUpGrade.RecLastUpdatedDt = System.DateTime.Now;
                    hireGroupUpGrade.UserDomainKey = hireGroupRepository.UserDomainKey;
                    hireGroupUpGrade.RecCreatedBy = "Cares";
                    hireGroupUpGrade.RowVersion = 0;
                    hireGroupUpGrade.RecLastUpdatedBy = "Cares";
                    hireGroupUpGrade.IsReadOnly = false;
                    hireGroupUpGrade.IsDeleted = false;
                    hireGroupUpGrade.IsPrivate = false;
                    hireGroupUpGrade.IsActive = false;
                    hireGroupUpGrade.HireGroupId = request.HireGroup.HireGroupId;
                    hireGroupUpGrade.AllowedHireGroupId = request.HireGroup.HireGroupId;
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
        /// <param name="request"></param>
        public HireGroup UpdateHireGroup(HireGroupAddRequest request)
        {
            hireGroupRepository.Update(request.HireGroup);
            hireGroupRepository.SaveChanges();
            IEnumerable<HireGroupDetail> hireGroupDetailsDbVersion = hireGroupDetailRepository.GetHireGroupDetailByHireGroupId(request.HireGroup.HireGroupId);
            IEnumerable<HireGroupUpGrade> hireGroupUpGradesDbVersion = hireGroupUpGradeRepository.FindByHireGroupId(request.HireGroup.HireGroupId);
            #region Hire Group Detail Updated
            var updatedHireGroupDetailItems = new List<long>();
            if (request.HireGroupDetails != null)
            {

                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var hireGroupDetail in request.HireGroupDetails)
                {
                    hireGroupDetail.RecCreatedDt = System.DateTime.Now;
                    hireGroupDetail.RecLastUpdatedDt = System.DateTime.Now;
                    hireGroupDetail.UserDomainKey = hireGroupRepository.UserDomainKey;
                    hireGroupDetail.RecCreatedBy = "Cares";
                    hireGroupDetail.RowVersion = 0;
                    hireGroupDetail.RecLastUpdatedBy = "Cares";
                    hireGroupDetail.IsReadOnly = false;
                    hireGroupDetail.IsDeleted = false;
                    hireGroupDetail.IsPrivate = false;
                    hireGroupDetail.IsActive = false;

                    //check whether item is updated or not in loop
                    int addCheck = 0;
                    foreach (var groupDetail in hireGroupDetailsDbVersion)
                    {
                        if (hireGroupDetail.HireGroupDetailId == groupDetail.HireGroupDetailId)
                        {
                            hireGroupDetailRepository.Update(hireGroupDetail);
                            hireGroupDetailRepository.SaveChanges();
                            updatedHireGroupDetailItems.Add(groupDetail.HireGroupDetailId);
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
            }
            if (hireGroupDetailsDbVersion != null)
            {
                //delete hire groups
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var groupDetail in hireGroupDetailsDbVersion)
                {
                    int delete = 0;
                    for (int i = 0; i < updatedHireGroupDetailItems.Count; i--)
                    {
                        if (groupDetail.HireGroupDetailId == updatedHireGroupDetailItems[i])
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
            #region Hire Group Up Garde Update
            var updatedHireGroupUpGradeItems = new List<long>();
            if (request.HireGroupUpGrades != null)
            {

                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var hireGroupUpGrade in request.HireGroupUpGrades)
                {
                    hireGroupUpGrade.RecCreatedDt = System.DateTime.Now;
                    hireGroupUpGrade.RecLastUpdatedDt = System.DateTime.Now;
                    hireGroupUpGrade.UserDomainKey = hireGroupRepository.UserDomainKey;
                    hireGroupUpGrade.RecCreatedBy = "Cares";
                    hireGroupUpGrade.RowVersion = 0;
                    hireGroupUpGrade.RecLastUpdatedBy = "Cares";
                    hireGroupUpGrade.IsReadOnly = false;
                    hireGroupUpGrade.IsDeleted = false;
                    hireGroupUpGrade.IsPrivate = false;
                    hireGroupUpGrade.IsActive = false;

                    //check whether item is updated or not in loop
                    int addCheck = 0;
                    foreach (var hireGroupUpGradeDb in hireGroupUpGradesDbVersion)
                    {
                        if (hireGroupUpGradeDb.HireGroupUpGradeId == hireGroupUpGrade.HireGroupUpGradeId)
                        {
                            hireGroupUpGradeRepository.Update(hireGroupUpGrade);
                            hireGroupUpGradeRepository.SaveChanges();
                            updatedHireGroupUpGradeItems.Add(hireGroupUpGradeDb.HireGroupUpGradeId);
                            addCheck = 1;
                        }

                    }
                    if (addCheck == 0)
                    {
                        hireGroupUpGrade.HireGroupId = request.HireGroup.HireGroupId;
                        hireGroupUpGrade.AllowedHireGroupId = request.HireGroup.HireGroupId;
                        hireGroupUpGradeRepository.Add(hireGroupUpGrade);
                        hireGroupUpGradeRepository.SaveChanges();
                    }
                }
            }
            if (hireGroupUpGradesDbVersion != null)
            {
                //delete hire groups
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var hireGroupUpGrade in hireGroupUpGradesDbVersion)
                {
                    int delete = 0;
                    for (int i = 0; i < updatedHireGroupDetailItems.Count; i--)
                    {
                        if (hireGroupUpGrade.HireGroupUpGradeId == updatedHireGroupDetailItems[i])
                        {
                            delete = 1;
                        }
                    }
                    if (delete == 0)
                    {
                        hireGroupUpGradeRepository.Delete(hireGroupUpGrade);
                        hireGroupUpGradeRepository.SaveChanges();
                    }

                }
            }
            #endregion
            var hirGroup = hireGroupRepository.Find(request.HireGroup.HireGroupId);
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
