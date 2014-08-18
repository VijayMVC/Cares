using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// tariff Type Reposiory interface
    /// </summary>
    public interface ITariffTypeRepository : IBaseRepository<TariffType, long>
    {
        /// <summary>
        ///  Get all tariff types, based on filters
        /// </summary>
        /// <param name="tariffTypeRequest"></param>
        /// <returns></returns>
        TariffTypeResponse GettariffTypes(TariffTypeRequest tariffTypeRequest);

        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(TariffType tariffType);
        /// <summary>
        /// Get Revisions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TariffType GetRevison(long id);
    }
}
