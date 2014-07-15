using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    public interface ITarrifTypeService
    {
        /// <summary>
        /// Load All Tarrif Types first time
        /// tarrifTypeRequest, use for user domain key
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeBaseResponse LoadAllTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
        /// <summary>
        /// Load tarrif type, based on search filters
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest);
    }
}
