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
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRepository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
        #region Private
        private readonly Dictionary<HireGroupDetailByColumn, Func<HireGroupDetail, object>> hireGroupDetailClause =
             new Dictionary<HireGroupDetailByColumn, Func<HireGroupDetail, object>>
                    {
                        { HireGroupDetailByColumn.HireGroupId, c => c.HireGroupId },
                        { HireGroupDetailByColumn.VehicleMakeId, c => c.VehicleMakeId },
                         { HireGroupDetailByColumn.VehicleModelId, c => c.VehicleModelId },
                        { HireGroupDetailByColumn.VehicleCategoryId, c => c.VehicleCategoryId },
                        { HireGroupDetailByColumn.ModelYear, c => c.ModelYear }
                       
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupDetail> DbSet
        {
            get
            {
                return db.HireGroupDetails;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IQueryable<HireGroupDetail> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Get Hire Group detail, based on filter criteria
        /// </summary>
        public HireGroupDetailResponse GetHireGroupDetails(HireGroupDetailRequest hireGroupDetailRequest)
        {
            int fromRow = (hireGroupDetailRequest.PageNo - 1) * hireGroupDetailRequest.PageSize;
            int toRow = hireGroupDetailRequest.PageSize;
            Expression<Func<HireGroupDetail, bool>> query =
                s =>
                    ((!(hireGroupDetailRequest.HireGroupId > 0) || s.HireGroupId == hireGroupDetailRequest.HireGroupId) &&
                     (!(hireGroupDetailRequest.VehicleMakeId > 0) ||
                      s.VehicleMakeId == hireGroupDetailRequest.VehicleMakeId) &&
                     (!(hireGroupDetailRequest.VehicleModelId > 0) ||
                      s.VehicleModelId == hireGroupDetailRequest.VehicleModelId) &&
                       (!(hireGroupDetailRequest.VehicleCategoryId > 0) ||
                      s.VehicleCategoryId == hireGroupDetailRequest.VehicleCategoryId));

            IEnumerable<HireGroupDetail> hireGroupDetails = hireGroupDetailRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(hireGroupDetailClause[hireGroupDetailRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(hireGroupDetailClause[hireGroupDetailRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList();
            return new HireGroupDetailResponse { HireGroupDetails = hireGroupDetails, TotalCount = DbSet.Count(query) };
        }

        #endregion
    }
}
