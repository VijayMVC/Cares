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
    /// Vehicle Model Repository
    /// </summary>
    public sealed class VehicleModelRepository : BaseRepository<VehicleModel>, IVehicleModelRepository
    {
        #region privte
        /// <summary>
        /// Vehicle Model Orderby clause
        /// </summary>
        private readonly Dictionary<VehicleModelByColumn, Func<VehicleModel, object>> vehicleModelOrderByClause = new Dictionary<VehicleModelByColumn, Func<VehicleModel, object>>
                    {

                        {VehicleModelByColumn.Code, c => c.VehicleModelCode},
                        {VehicleModelByColumn.Name, n => n.VehicleModelName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleModelRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleModel> DbSet
        {
            get
            {
                return db.VehicleModels;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleModel> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Vehicle Model
        /// </summary>
        public IEnumerable<VehicleModel> SearchVehicleModel(VehicleModelSearcgRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<VehicleModel, bool>> query =
                vehicleModel =>
                    (string.IsNullOrEmpty(request.VehicleModelCodeNameFilterText) ||
                     (vehicleModel.VehicleModelCode.Contains(request.VehicleModelCodeNameFilterText)) ||
                     (vehicleModel.VehicleModelName.Contains(request.VehicleModelCodeNameFilterText))) && (vehicleModel.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(vehicleModelOrderByClause[request.VehicleModelOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(vehicleModelOrderByClause[request.VehicleModelOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();  
        }

        /// <summary>
        /// Self code duplication check of Vehicle Model
        /// </summary>
        public bool VehicleModelCodeDuplicationCheck(VehicleModel vehicleModel)
        {
            return
                DbSet.Count(
                    dbvehicleModel =>
                        dbvehicleModel.VehicleModelCode == vehicleModel.VehicleModelCode &&
                        dbvehicleModel.VehicleModelId != vehicleModel.VehicleModelId
                        && dbvehicleModel.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion
    }
}
