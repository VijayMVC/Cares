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
        #endregion
        #region Constructors
        public HireGroupService(IHireGroupRepository hireGroupRepository, ICompanyRepository companyRepository)
        {
            this.hireGroupRepository = hireGroupRepository;
            this.companyRepository = companyRepository;
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
            return new HireGroupBaseResponse{Companies = companies,ParentHireGroups =parentHireGroups };
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

        #endregion


    }
}
