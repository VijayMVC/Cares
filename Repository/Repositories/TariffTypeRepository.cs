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
                        { TariffTypeByColumn.TariffTypeCode, c => c.TariffTypeCode },
                        { TariffTypeByColumn.PricingStrategyId, c => c.PricingStrategy.PricingStrategyId },
                        { TariffTypeByColumn.OperationId, c => c.Operation.OperationId },
                          { TariffTypeByColumn.MeasurementUnitId, c => c.MeasurementUnit.MeasurementUnitId },
                        { TariffTypeByColumn.DurationFrom, c => c.DurationFrom },
                        { TariffTypeByColumn.DurationTo, c => c.DurationTo },
                        { TariffTypeByColumn.GracePeriod, c => c.GracePeriod },
                        { TariffTypeByColumn.EffectiveDate, c => c.EffectiveDate }

                       
                    };
        #endregion.

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
            return DbSet.Where(p => p.UserDomainKey == UserDomainKey && p.ChildTariffTypeId == null).ToList();
        }

        /// <summary>
        /// Get All Tariff Types based on search crateria
        /// </summary>
        public TariffTypeResponse GettariffTypes(TariffTypeSearchRequest tariffTypeRequest)
        {
            int fromRow = (tariffTypeRequest.PageNo - 1) * tariffTypeRequest.PageSize;
            int toRow = tariffTypeRequest.PageSize;
            Expression<Func<TariffType, bool>> query =
                            s => ((string.IsNullOrEmpty(tariffTypeRequest.SearchString) || s.TariffTypeCode.Contains(tariffTypeRequest.SearchString) || s.TariffTypeName.Contains(tariffTypeRequest.SearchString)) &&
                                (!(tariffTypeRequest.OperationId > 0) || s.OperationId == tariffTypeRequest.OperationId) &&
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
            LoadProperty(tariffType, () => tariffType.Operation);
            LoadProperty(tariffType, () => tariffType.MeasurementUnit);
            LoadProperty(tariffType, () => tariffType.PricingStrategy);
        }

        /// <summary>
        /// Find Tariff Type By Id
        /// </summary>
        public override TariffType Find(long tariffTypeId)
        {
            return
              DbSet.Include(tariffType => tariffType.Operation)
                  .Include(tariffType => tariffType.Operation.Department)
                  .Include(tariffType => tariffType.Operation.Department.Company)
                  .FirstOrDefault(tariffType => tariffType.TariffTypeId == tariffTypeId);
        }

        /// <summary>
        /// Get Revision
        /// </summary>
        public TariffType GetRevison(long tariffTypeId)
        {
            return
              DbSet.Include(tariffType => tariffType.Operation)
                  .Include(tariffType => tariffType.Operation.Department)
                  .Include(tariffType => tariffType.Operation.Department.Company)
                  .FirstOrDefault(tariffType => tariffType.ChildTariffTypeId == tariffTypeId);
        }

        /// <summary>
        /// Get Tariff Type By Code
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TariffType> GetByTariffTypeCode(string tariffTypeCode)
        {
            return DbSet.Where(tariffType => tariffType.UserDomainKey == UserDomainKey && tariffType.ChildTariffTypeId == null
                && tariffType.TariffTypeCode.ToLower() == tariffTypeCode.ToLower()).ToList();
        }

        /// <summary>
        /// Is Tariff Type Ovelap
        /// </summary>
        /// <param name="tariffType"></param>
        /// <returns></returns>
        public bool IsTariffTypeOvelap(TariffType tariffType)
        {
            return DbSet.Count(tt => tt.TariffTypeId != tariffType.TariffTypeId && (tt.DurationTo + tt.GracePeriod) > tariffType.DurationFrom
        && tt.DurationFrom < tariffType.DurationTo && tt.UserDomainKey == UserDomainKey && tt.MeasurementUnitId == tariffType.MeasurementUnitId
        && tt.EffectiveDate == tariffType.EffectiveDate && tt.ChildTariffTypeId == null) > 0;
        }
        #endregion
    }
}
