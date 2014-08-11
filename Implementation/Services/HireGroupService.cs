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
        #endregion
        #region Constructors
        public HireGroupService(IHireGroupRepository hireGroupRepository, ICompanyRepository companyRepository, IVehicleCategoryRepository vehicleCategoryRepository,
            IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository)
        {
            this.hireGroupRepository = hireGroupRepository;
            this.companyRepository = companyRepository;
            this.vehicleCategoryRepository = vehicleCategoryRepository;
            this.vehicleMakeRepository = vehicleMakeRepository;
            this.vehicleModelRepository = vehicleModelRepository;
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
        /// Load tarrif type, based on search filters
        /// </summary>
        /// <param name="hireGroupSearchRequest"></param>
        /// <returns></returns>
        public HireGroupSearchResponse LoadHireGroups(HireGroupSearchRequest hireGroupSearchRequest)
        {
            return hireGroupRepository.GetHireGroups(hireGroupSearchRequest);
        }

        #endregion


    }
}
