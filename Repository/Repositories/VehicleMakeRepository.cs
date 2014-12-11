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
    /// Vehicle Make Repository
    /// </summary>
    public sealed class VehicleMakeRepository : BaseRepository<VehicleMake>, IVehicleMakeRepository
    {
        #region privte
        /// <summary>
        /// Vehicle Make Orderby clause
        /// </summary>
        private readonly Dictionary<VehicleMakeByColumn, Func<VehicleMake, object>> vehicleMakeOrderByClause = new Dictionary<VehicleMakeByColumn, Func<VehicleMake, object>>
                    {
                        {VehicleMakeByColumn.Code, d => d.VehicleMakeCode },
                        {VehicleMakeByColumn.Name, c => c.VehicleMakeName}                       
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleMakeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleMake> DbSet
        {
            get
            {
                return db.VehicleMakes;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Makes for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleMake> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Vehicle Make
        /// </summary>
        public IEnumerable<VehicleMake> SearchVehicleMake(VehicleMakeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<VehicleMake, bool>> query =
                vehicleMake =>
                    (string.IsNullOrEmpty(request.VehicleMakeCodeNameText) || (vehicleMake.VehicleMakeCode.Contains(request.VehicleMakeCodeNameText)) ||
                     (vehicleMake.VehicleMakeName.Contains(request.VehicleMakeCodeNameText))) && (vehicleMake.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(vehicleMakeOrderByClause[request.VehicleMakeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(vehicleMakeOrderByClause[request.VehicleMakeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();   
        }


        /// <summary>
        /// Vehicle Make Self code duplication check
        /// </summary>
        public bool VehicleMakeCodeDuplicationCheck(VehicleMake vehicleMakeReq)
        {
            return
                DbSet.Count(
                    vehiclemake =>
                        vehiclemake.VehicleMakeCode == vehicleMakeReq.VehicleMakeCode &&
                        vehiclemake.VehicleMakeId != vehicleMakeReq.VehicleMakeId) > 0;
        }
        #endregion
    }
}
