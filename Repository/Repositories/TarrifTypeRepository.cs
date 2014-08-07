using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;


namespace Cares.Repository.Repositories
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
        #region Constructor
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
        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(TarrifType tarrifType)
        {
            LoadProperty<TarrifType>(tarrifType, "Operation");
            LoadProperty(tarrifType, () => tarrifType.Operation);
            LoadProperty(tarrifType, () => tarrifType.MeasurementUnit);
            LoadProperty(tarrifType, () => tarrifType.PricingStrategy);
            LoadProperty(tarrifType, () => tarrifType.Company);
        }
        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
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
