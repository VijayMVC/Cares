using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
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

        public IEnumerable<TarrifType> LoadAll()
        {
            return tarrifTypeReposiory.GetAll();
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
