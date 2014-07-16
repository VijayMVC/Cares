using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        /// <summary>
        /// Get All Tariff Types for User Domain Key
        /// </summary>
        /// <returns></returns>
         public override IQueryable<TarrifType> GetAll()
        {
            return DbSet.Where(p => p.UserDomainKey == UserDomaingKey);
        }

        public TarrifTypeResponse GetTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            IEnumerable<TarrifType> tarrifTypes= DbSet.Where(p => p.UserDomainKey == UserDomaingKey);
            return new TarrifTypeResponse { TarrifTypes = tarrifTypes, TotalCount = 10 };
        }
        #endregion

    }
}
