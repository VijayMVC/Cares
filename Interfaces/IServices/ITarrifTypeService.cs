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
    }
}
