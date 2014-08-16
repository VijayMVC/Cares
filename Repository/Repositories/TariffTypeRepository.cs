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
    /// tariff Type Repository
    /// </summary>
    public sealed class TariffTypeRepository : BaseRepository<TariffType>, ITariffTypeRepository
    {
        #region Private
        private readonly Dictionary<TariffTypeByColumn, Func<TariffType, object>> tariffTypeClause =
             new Dictionary<TariffTypeByColumn, Func<TariffType, object>>
                    {
                        { TariffTypeByColumn.TariffTypeName, c => c.TariffTypeName },
                        { TariffTypeByColumn.TariffTypeCode, c => c.TariffTypeCode }
                       
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        #endregion
        #region Protected
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<TariffType> DbSet
        {
            get
            {
                return db.TariffTypes;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Tariff Types for User Domain Key
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<TariffType> GetAll()
        {
            return DbSet.Where(p => p.UserDomainKey == UserDomainKey && p.ChildTariffTypeId == 0).ToList();
        }
        /// <summary>
        /// Get All Tariff Types based on search crateria
        /// </summary>
        public TariffTypeResponse GettariffTypes(TariffTypeRequest tariffTypeRequest)
        {
            int fromRow = (tariffTypeRequest.PageNo - 1) * tariffTypeRequest.PageSize;
            int toRow = tariffTypeRequest.PageSize;
            Expression<Func<TariffType, bool>> query =
                            s => ((!(tariffTypeRequest.OperationId > 0) || s.OperationId == tariffTypeRequest.OperationId) &&
                                (!(tariffTypeRequest.MeasurementUnitId > 0) || s.MeasurementUnitId == tariffTypeRequest.MeasurementUnitId) &&
                                 (string.IsNullOrEmpty(tariffTypeRequest.TariffTypeCode) || s.TariffTypeCode.Contains(tariffTypeRequest.TariffTypeCode))) &&
                                 (s.ChildTariffTypeId == 0 || s.ChildTariffTypeId == null);

            IEnumerable<TariffType> tariffTypes = tariffTypeRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(tariffTypeClause[tariffTypeRequest.TariffTypeByOrder]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(tariffTypeClause[tariffTypeRequest.TariffTypeByOrder]).Skip(fromRow).Take(toRow).ToList();


            return new TariffTypeResponse { TariffTypes = tariffTypes, TotalCount = DbSet.Count(query) };
        }
        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(TariffType tariffType)
        {
            LoadProperty<TariffType>(tariffType, "Operation");
            LoadProperty(tariffType, () => tariffType.Operation);
            LoadProperty(tariffType, () => tariffType.MeasurementUnit);
            LoadProperty(tariffType, () => tariffType.PricingStrategy);
        }
        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
        public override TariffType Find(long id)
        {
            return
              DbSet.Include(tariffType => tariffType.Operation)
                  .Include(tariffType => tariffType.Operation.Department)
                  .Include(tariffType => tariffType.Operation.Department.Company)
                  .FirstOrDefault(tariffType => tariffType.TariffTypeId == id);
        }
        /// <summary>
        /// Get Revision
        /// </summary>
        public TariffType GetRevison(long id)
        {
            return
              DbSet.Include(tariffType => tariffType.Operation)
                  .Include(tariffType => tariffType.Operation.Department)
                  .Include(tariffType => tariffType.Operation.Department.Company)
                  .FirstOrDefault(tariffType => tariffType.ChildTariffTypeId == id);
        }
        #endregion
    }
}
