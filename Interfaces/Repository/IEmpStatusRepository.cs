using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Emp Status Repository Interface
    /// </summary>
    public interface IEmpStatusRepository : IBaseRepository<EmpStatus, long>
    {

        /// <summary>
        /// Search Employee status
        /// </summary>
        IEnumerable<EmpStatus> SearchEmpStatus(EmpSearchRequest request, out int rowCount);
        
        /// <summary>
        /// Employee status code duplication check
        /// </summary>
        bool DoesEmpStatusCodeExist(EmpStatus empStatus);
    }
}
