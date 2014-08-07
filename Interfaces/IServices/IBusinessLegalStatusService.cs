using System.Linq;
using Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Legal Status Service Interface
    /// </summary>
    public interface IBusinessLegalStatusService
    {
        /// <summary>
        /// Get all business legal status records
        /// </summary>
        IQueryable<BusinessLegalStatus> LoadAll();
    }
}
