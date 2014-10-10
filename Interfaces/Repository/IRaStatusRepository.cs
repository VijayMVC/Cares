using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Ra Status Repository
    /// </summary>
    public interface IRaStatusRepository : IBaseRepository<RaStatus, long>
    {
        /// <summary>
        /// Find By Status Key
        /// </summary>
        /// <param name="statusKey"></param>
        /// <returns></returns>
        RaStatus FindByStatusKey(short statusKey);
    }
}
