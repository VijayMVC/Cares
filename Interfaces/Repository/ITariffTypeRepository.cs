using System.Collections.Generic;
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
        /// <param name="tariffTypeSearchRequest"></param>
        /// <returns></returns>
        TariffTypeResponse GettariffTypes(TariffTypeSearchRequest tariffTypeSearchRequest);

        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(TariffType tariffType);

        /// <summary>
        /// Get Revisions
        /// </summary>
        /// <param name="tariffTypeId"></param>
        /// <returns></returns>
        TariffType GetRevison(long tariffTypeId);

        /// <summary>
        /// Get Tariff Type By Code
        /// </summary>
        /// <returns></returns>
        IEnumerable<TariffType> GetByTariffTypeCode(string tariffTypeCode);
    }
}
