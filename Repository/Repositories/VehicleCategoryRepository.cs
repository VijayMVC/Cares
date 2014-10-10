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
    /// Vehicle Category Repository
    /// </summary>
    public class VehicleCategoryRepository : BaseRepository<VehicleCategory>, IVehicleCategoryRepository
    {
        #region privte
        /// <summary>
        ///  Vehicle Category Orderby clause
        /// </summary>
        private readonly Dictionary<VehicleCategoryByColumn, Func<VehicleCategory, object>> vehicleCategoryOrderByClause = 
            new Dictionary<VehicleCategoryByColumn, Func<VehicleCategory, object>>
                    {
                        {VehicleCategoryByColumn.Code, d => d.VehicleCategoryCode},
                        {VehicleCategoryByColumn.Name, c => c.VehicleCategoryName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleCategoryRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleCategory> DbSet
        {
            get
            {
                return db.VehicleCategories;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Categories for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleCategory> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Vehicle Category
        /// </summary>
        public IEnumerable<VehicleCategory> SearchVehicleCategory(VehicleCategorySearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<VehicleCategory, bool>> query =
                vehicleCategory =>
                    (string.IsNullOrEmpty(request.VehicleCategoryFilterText) || (vehicleCategory.VehicleCategoryName.Contains(request.VehicleCategoryFilterText)) ||
                     (vehicleCategory.VehicleCategoryCode.Contains(request.VehicleCategoryFilterText))) ;

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(vehicleCategoryOrderByClause[request.VehicleCategoryOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(vehicleCategoryOrderByClause[request.VehicleCategoryOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Vehicle Category Self code duplication check
        /// </summary>
        public bool VehicleCategoryCodeDuplicationCheck(VehicleCategory vehicleCategory)
        {
            return DbSet.Count(
                dbvehicleCategory => dbvehicleCategory.VehicleCategoryCode == vehicleCategory.VehicleCategoryCode &&
                                     dbvehicleCategory.VehicleCategoryId != vehicleCategory.VehicleCategoryId) > 0;
        }
        #endregion
    }
}
