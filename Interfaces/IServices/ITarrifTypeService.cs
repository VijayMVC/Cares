using System.Collections.Generic;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
namespace Interfaces.IServices
{
    /// <summary>
    /// Tarrif Type Service Interface
    /// </summary>
    public interface ITarrifTypeService
    {
        /// <summary>
        /// Get All Tarrif Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<TarrifType> LoadAll();
        /// <summary>
        /// Load tarrif type, based on search filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
        /// <summary>
        /// Find Tarrif Type By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TarrifType FindTarrifType(long id);
        /// <summary>
        /// Add Tarrif Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        TarrifType AddTarrifType(TarrifType tarrifType);
        /// <summary>
        /// Update Tarrif Type
        /// </summary>
        /// <param name="tarrifType"></param>
        /// <returns></returns>
        bool UpdateTarrifType(TarrifType tarrifType);
        /// <summary>
        /// Get All Base Data
        /// </summary>
        /// <returns></returns>
        TarrifTypeBaseResponse GetBaseData();
    }
}
