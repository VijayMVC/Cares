
using System.Linq;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Tarrif Type Reposiory interface
    /// </summary>
    public interface ITarrifTypeRepository : IBaseRepository<TarrifType, int>
    {
        /// <summary>
        /// Get all Tarrif types with respect to user domain key
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeBaseResponse GetAllTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
        /// <summary>
        ///  Get all Tarrif types, based on filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeResponse GetTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
    }
}
