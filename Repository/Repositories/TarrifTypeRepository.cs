using System.Data.Entity;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public sealed class TarrifTypeRepository : BaseRepository<TarrifType>, ITarrifTypeRepository
    {
        #region Private
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        #endregion
        #region Protected
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<TarrifType> DbSet
        {
            get
            {
                return db.TarrifTypes;
            }
        }
        #endregion
        #region Public

        public TarrifTypeBaseResponse GetAllTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            throw new System.NotImplementedException();
        }

        public TarrifTypeResponse GetTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
