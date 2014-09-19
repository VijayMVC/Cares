using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Additional Driver Charge Repository Interface
    /// </summary>
    public interface IAdditionalDriverChargeRepository : IBaseRepository<AdditionalDriverCharge, long>
    {

        /// <summary>
        /// Get All Additional Driver Charges based on search crateria
        /// </summary>
        AdditionalDriverChargeSearchResponse GetAdditionalDriverCharges(AdditionalDriverChargeSearchRequest request);

        /// <summary>
        /// Get Additional Driver Charge By Tariff Type Code
        /// </summary>
        IEnumerable<AdditionalDriverCharge> FindByTariffTypeCode(string tariffTypeCode);

        /// <summary>
        /// Get Additional Driver Charge Revisions By Id
        /// </summary>
        AdditionalDriverCharge GetRevision(long additionalDriverChargeId);
    }
}
