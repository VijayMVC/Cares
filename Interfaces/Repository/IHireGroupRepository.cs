using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Hire Group Interface
    /// </summary>
    public interface IHireGroupRepository : IBaseRepository<HireGroup, long>
    {
        /// <summary>
        /// Get List Of Hire Group based on search criteria
        /// </summary>
        /// <param name="hireGroupSearchRequest"></param>
        /// <returns></returns>
        HireGroupSearchResponse GetHireGroups(HireGroupSearchRequest hireGroupSearchRequest);
        /// <summary>
        /// Get Parent Hire Groups
        /// </summary>
        /// <returns></returns>
        IEnumerable<HireGroup> GetParentHireGroups();

        /// <summary>
        /// Get Hire Groups that are not parent hire groups 
        /// </summary>
        IEnumerable<HireGroup> GetHireGroupList();


    }
}






