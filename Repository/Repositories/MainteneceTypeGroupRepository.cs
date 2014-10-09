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
    /// Maintenance Type Group Repository
    /// </summary>
    public sealed class MainteneceTypeGroupRepository : BaseRepository<MaintenanceTypeGroup>, IMainteneceTypeGroupRepository
    {
        #region privte
        /// <summary>
        /// Maintenance Type Group Orderby clause for sorting 
        /// </summary>
        private readonly Dictionary<MainteneceTypeGroupByColumn, Func<MaintenanceTypeGroup, object>> mainteneceTypeGroupOrderByClause = 
            new Dictionary<MainteneceTypeGroupByColumn, Func<MaintenanceTypeGroup, object>>
                    {
                        {MainteneceTypeGroupByColumn.Code, d => d.MaintenanceTypeGroupCode},
                        {MainteneceTypeGroupByColumn.Name, c => c.MaintenanceTypeGroupName}
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainteneceTypeGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MaintenanceTypeGroup> DbSet
        {
            get
            {
                return db.MaintenanceTypeGroups;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Maintenance Type Group for User Domain Key
        /// </summary>
        public override IEnumerable<MaintenanceTypeGroup> GetAll()
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Maintenance Type Group By Id
        /// </summary>
        public MaintenanceTypeGroup Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Search Maintenece Type Group
        /// </summary>
        public IEnumerable<MaintenanceTypeGroup> SearchMainteneceTypeGroup(MainteneceTypeGroupSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<MaintenanceTypeGroup, bool>> query =
                maintenanceTypeGroup =>
                    (string.IsNullOrEmpty(request.MainteneceTypeGroupFilterText) ||
                     (maintenanceTypeGroup.MaintenanceTypeGroupCode.Contains(request.MainteneceTypeGroupFilterText)) ||
                     (maintenanceTypeGroup.MaintenanceTypeGroupName.Contains(request.MainteneceTypeGroupFilterText)));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(mainteneceTypeGroupOrderByClause[request.MainteneceTypeGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(mainteneceTypeGroupOrderByClause[request.MainteneceTypeGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }


        /// <summary>
        /// Self-code duplication check
        /// </summary>
        public bool IsMaintenanceTypeGroupCodeExist(MaintenanceTypeGroup maintenanceTypeGroupReq)
        {
            return
                DbSet.Count(
                    maintenanceTypeGroup =>
                        maintenanceTypeGroup.MaintenanceTypeGroupCode == maintenanceTypeGroupReq.MaintenanceTypeGroupCode &&
                        maintenanceTypeGroup.MaintenanceTypeGroupId != maintenanceTypeGroupReq.MaintenanceTypeGroupId) > 0;
        }

        #endregion
    }
}
