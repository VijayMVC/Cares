using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Tarrif Type Reposiory interface
    /// </summary>
    public interface ITarrifTypeRepository : IBaseRepository<TarrifType, long>
    {
        /// <summary>
        ///  Get all Tarrif types, based on filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeResponse GetTarrifTypes(TarrifTypeRequest tarrifTypeRequest);

        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(TarrifType tarrifType);
        /// <summary>
        /// Get Revisions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TarrifType GetRevison(long id);
    }
}
