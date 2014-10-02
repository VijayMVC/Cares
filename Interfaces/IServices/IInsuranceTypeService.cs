using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Insurance Type Service Interface
    /// </summary>
    public interface IInsuranceTypeService
    {
        /// <summary>
        /// Get All For RA
        /// </summary>
        IEnumerable<InsuranceType> GetAllForRa();

    }
}
