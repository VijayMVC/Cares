using System.Collections.Generic;
using Cares.Models.DomainModels;
namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Phone Repository Interface
    /// </summary>
    public interface IPhoneRepository : IBaseRepository<Phone, long>
    {
        /// <summary>
        /// Get associated Phones with Work Location Id
        /// </summary>
        IEnumerable<Phone> GetPhonesByWorkLocationId(long workLocationId);
    }
}
