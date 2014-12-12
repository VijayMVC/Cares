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
    /// Vehicle Check List Repository
    /// </summary>
    public sealed class VehicleCheckListRepository : BaseRepository<VehicleCheckList>, IVehicleCheckListRepository
    {
        #region privte
        /// <summary>
        /// Vehicle CheckList Orderby clause
        /// </summary>
        private readonly Dictionary<VehicleCheckListByColumn, Func<VehicleCheckList, object>> vehicleCheckListOrderByClause = new Dictionary<VehicleCheckListByColumn, Func<VehicleCheckList, object>>
                    {
                        {VehicleCheckListByColumn.Code, d => d.VehicleCheckListCode },
                        {VehicleCheckListByColumn.Name, c => c.VehicleCheckListName}                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Vehicle Check List Repository Constructor
        /// </summary>
        public VehicleCheckListRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleCheckList> DbSet
        {
            get
            {
                return db.VehicleCheckLists;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Vehicle Check List for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleCheckList> GetAll()
        {
            return DbSet.Where(vcl => vcl.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Vehicle CheckList
        /// </summary>
        public IEnumerable<VehicleCheckList> SearchVehicleCheckList(VehicleCheckListSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<VehicleCheckList, bool>> query =
                vehicleCheckList =>
                    (string.IsNullOrEmpty(request.VehicleCheckListFilterText) ||
                     (vehicleCheckList.VehicleCheckListCode.Contains(request.VehicleCheckListFilterText)) ||
                     (vehicleCheckList.VehicleCheckListName.Contains(request.VehicleCheckListFilterText)))
                     && (vehicleCheckList.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(vehicleCheckListOrderByClause[request.VehicleCheckListOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(vehicleCheckListOrderByClause[request.VehicleCheckListOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// sel-Code duplication check
        /// </summary>
        public bool DoesVehicleCheckListCodeExist(VehicleCheckList vehicleCheckList)
        {
            return
                DbSet.Count(
                    dbvehicleCheckList =>
                        dbvehicleCheckList.VehicleCheckListId != vehicleCheckList.VehicleCheckListId &&
                        dbvehicleCheckList.VehicleCheckListCode == vehicleCheckList.VehicleCheckListCode &&
                        dbvehicleCheckList.UserDomainKey == UserDomainKey) > 0;
        }

        #endregion
    }
}
