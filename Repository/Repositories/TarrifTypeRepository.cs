using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.Common;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using Repository.BaseRepository;
namespace Repository.Repositories
{
    /// <summary>
    /// Tarrif Type Repository
    /// </summary>
    public sealed class TarrifTypeRepository : BaseRepository<TarrifType>, ITarrifTypeRepository
    {
        #region Private
        private readonly Dictionary<TarrifTypeByColumn, Func<TarrifType, object>> tarrifTypeClause =
             new Dictionary<TarrifTypeByColumn, Func<TarrifType, object>>
                    {
                        { TarrifTypeByColumn.TariffTypeName, c => c.TariffTypeName },
                        { TarrifTypeByColumn.TariffTypeCode, c => c.TariffTypeCode }
                       
                    };
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
            return DbSet.Where(p => p.UserDomainKey == UserDomainKey && p.ChildTariffTypeId == 0);
        }
        /// <summary>
        /// Get All Tariff Types based on search crateria
        /// </summary>
        /// <param name="tarrifTypeRequest"></param>
        /// <returns></returns>
        public TarrifTypeResponse GetTarrifTypes(TarrifTypeRequest tarrifTypeRequest)
        {
            int fromRow = (tarrifTypeRequest.PageNo - 1) * tarrifTypeRequest.PageSize;
            int toRow = tarrifTypeRequest.PageSize;
            Expression<Func<TarrifType, bool>> query =
                            s => ((!(tarrifTypeRequest.OperationId > 0) || s.OperationId == tarrifTypeRequest.OperationId) &&
                                (!(tarrifTypeRequest.MeasurementUnitId > 0) || s.MeasurementUnitId == tarrifTypeRequest.MeasurementUnitId) &&
                                 (string.IsNullOrEmpty(tarrifTypeRequest.TarrifTypeCode) || s.TariffTypeCode.Contains(tarrifTypeRequest.TarrifTypeCode))) &&
                                 (s.ChildTariffTypeId == 0);

            IEnumerable<TarrifType> tarrifTypes = tarrifTypeRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(tarrifTypeClause[tarrifTypeRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(tarrifTypeClause[tarrifTypeRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList();


            return new TarrifTypeResponse { TarrifTypes = tarrifTypes, TotalCount = DbSet.Count(query) };
        }
        public void LoadDependencies(TarrifType tarrifType)
        {
            LoadProperty<TarrifType>(tarrifType, "Operation");
            LoadProperty(tarrifType, () => tarrifType.Operation);
            LoadProperty(tarrifType, () => tarrifType.MeasurementUnit);
            LoadProperty(tarrifType, () => tarrifType.PricingStrategy);
        }
        /// <summary>
        /// Find By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override TarrifType Find(long id)
        {
            return
              DbSet.Include(tarrifType => tarrifType.Operation)
                  .Include(tarrifType => tarrifType.Operation.Department)
                  .FirstOrDefault(tarrifType => tarrifType.TariffTypeId == id);
        }
        /// <summary>
        /// Get Revision
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TarrifType GetRevison(long id)
        {
            return
              DbSet.Include(tarrifType => tarrifType.Operation)
                  .Include(tarrifType => tarrifType.Operation.Department)
                  .FirstOrDefault(tarrifType => tarrifType.ChildTariffTypeId == id);
        }
        #endregion
    }
}
