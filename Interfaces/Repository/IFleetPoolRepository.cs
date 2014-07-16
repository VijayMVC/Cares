using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.RequestModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// FleetPool Repository
    /// </summary>
    public interface IFleetPoolRepository:IBaseRepository<FleetPool,int>
    {
        /// <summary>
        /// Get All FleetPools
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        IQueryable<FleetPool> GetAll(FleetPoolSearchRequest searchRequest);
    }
}
