using Interfaces.IServices;
using Interfaces.Repository;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// Tarrif TypeS ervice
    /// </summary>
    public class TarrifTypeService : ITarrifTypeService
    {
        #region Private
        private readonly ITarrifTypeRepository tarrifTypeReposiory;
        #endregion
        #region Constructors
        public TarrifTypeService(ITarrifTypeRepository tarrifTypeReposiory)
        {
            this.tarrifTypeReposiory = tarrifTypeReposiory;

        }
        #endregion
        #region Public
        /// <summary>
        /// Load All Tarrif Types first time
        /// tarrifTypeRequest, use for user domain key
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        public TarrifTypeBaseResponse LoadAllTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            return tarrifTypeReposiory.GetAllTarrifTypes(tarrifTypeRequest);
        }

        /// <summary>
        /// Load tarrif type, based on search filters
      /// </summary>
      /// <param name="tarrifTypeRequest"></param>
      /// <returns></returns>
        public TarrifTypeResponse LoadTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            return tarrifTypeReposiory.GetTarrifTypes(tarrifTypeRequest);
        }
        #endregion

    }
}
