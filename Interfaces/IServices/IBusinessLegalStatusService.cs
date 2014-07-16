using System.Linq;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
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
