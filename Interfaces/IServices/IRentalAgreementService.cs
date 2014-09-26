using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Rental Agreement Service Interface
    /// </summary>
    public interface IRentalAgreementService
    {
        /// <summary>
        /// Get All Base Data
        /// </summary>
        RentalAgreementBaseDataResponse GetBaseData();

        /// <summary>
        /// Generate Bill for RA
        /// </summary>
        RaMain GenerateBill(RaMain request);
    }
}
