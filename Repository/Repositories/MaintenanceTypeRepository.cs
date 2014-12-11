using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Maintenance Type Repository
    /// </summary>
    public sealed class MaintenanceTypeRepository : BaseRepository<MaintenanceType>, IMaintenanceTypeRepository
    {
        #region privte
        /// <summary>
        /// Maintenance Type Order by clause
        /// </summary>
        private readonly Dictionary<MaintenanceTypeByColumn, Func<MaintenanceType, object>> maintenanceTypeOrderByClause = new Dictionary<MaintenanceTypeByColumn, Func<MaintenanceType, object>>
                    {

                        {MaintenanceTypeByColumn.Code, c => c.MaintenanceTypeCode},
                        {MaintenanceTypeByColumn.Name, n => n.MaintenanceTypeName},
                        {MaintenanceTypeByColumn.MaintenanceTypeGroup, d=> d.MaintenanceTypeGroup.MaintenanceTypeGroupId}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Maintenance Type Repository Constructor
        /// </summary>
        public MaintenanceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MaintenanceType> DbSet
        {
            get
            {
                return db.MaintenanceTypes;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Maintenance Type for User Domain Key
        /// </summary>
        public override IEnumerable<MaintenanceType> GetAll()
        {
            return DbSet.Where(mt => mt.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Association check b/w Maintenece Type Group and Maintenece Type
        /// </summary>
        public bool IsMainteneceTypeGroupAssociatedWithMainteneceType(long mainteneceTypeGroupId)
        {
            return DbSet.Count(mainteneceType => mainteneceType.MaintenanceTypeGroupId == mainteneceTypeGroupId) > 0;
        }

        /// <summary>
        /// Search  Maintenance Type
        /// </summary>
        public IEnumerable<MaintenanceType> SearchMaintenanceType(MaintenanceTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<MaintenanceType, bool>> query =
                maintenanceType =>
                    (string.IsNullOrEmpty(request.MaintenanceTypeCodeNameText) ||
                     (maintenanceType.MaintenanceTypeCode.Contains(request.MaintenanceTypeCodeNameText)) ||
                     (maintenanceType.MaintenanceTypeName.Contains(request.MaintenanceTypeCodeNameText))) &&
                    (!request.MaintenanceTypeGroypId.HasValue || request.MaintenanceTypeGroypId == maintenanceType.MaintenanceTypeGroupId)
                    && (maintenanceType.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(maintenanceTypeOrderByClause[request.MaintenanceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(maintenanceTypeOrderByClause[request.MaintenanceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// MaintenanceType code duplication check
        /// </summary>
        public bool MaintenanceTypeCodeDuplicationCheck(MaintenanceType maintenanceType)
        {
            return
                DbSet.Count(
                    dbmaintenanceType =>
                        dbmaintenanceType.MaintenanceTypeCode == maintenanceType.MaintenanceTypeCode &&
                        dbmaintenanceType.MaintenanceTypeId != maintenanceType.MaintenanceTypeId) > 0;
        }

        /// <summary>
        /// Load detail object of Maintenance Type
        /// </summary>
        public MaintenanceType LoadMaintenanceTypeWithDetail(long maintenanceTypeId)
        {
            return DbSet.Include(maintenanceType => maintenanceType.MaintenanceTypeGroup)
               .FirstOrDefault(maintenanceType => maintenanceType.MaintenanceTypeId == maintenanceTypeId);
        }
        #endregion
    }
}
