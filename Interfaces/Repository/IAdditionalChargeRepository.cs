using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Additional Charge Repository
    /// </summary>
    public interface IAdditionalChargeRepository : IBaseRepository<AdditionalCharge, long>
    {
        /// <summary>
        /// Get Additional Charges By Addition Charge Type Id
        /// </summary>
        /// <param name="additionChargeTypeId"></param>
        /// <returns></returns>
        IEnumerable<AdditionalCharge> GetAdditionalChargesByAdditionChargeTypeId(long additionChargeTypeId);

        /// <summary>
        /// Get All For RA
        /// </summary>
        IEnumerable<AdditionalCharge> GetAllForRa();
    }
}
