using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;


namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Tarrif Type Service Interface
    /// </summary>
    public interface ITarrifTypeService
    {
        /// <summary>
        /// Get All Tarrif Types
        /// </summary>
        IEnumerable<TarrifType> LoadAll();
        /// <summary>
        /// Load tarrif type, based on search filters
        /// </summary>
        TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
        /// <summary>
        /// Find Tarrif Type By ID
        /// </summary>
        TariffTypeDetailResponse FindDetailById(long id);
        /// <summary>
        /// Add Tarrif Type
        /// </summary>
        TarrifType AddTarrifType(TarrifType tarrifType);
        /// <summary>
        /// Update Tarrif Type
        /// </summary>
        TarrifType UpdateTarrifType(TarrifType tarrifType);
        /// <summary>
        /// Get All Base Data
        /// </summary>
        TarrifTypeBaseResponse GetBaseData();
    }
}
