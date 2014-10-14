using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Rental Agreement Repository Interface
    /// </summary>
    public interface IRentalAgreementRepository : IBaseRepository<RaMain, long>
    {
        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(RaMain raMain);
    }
}
