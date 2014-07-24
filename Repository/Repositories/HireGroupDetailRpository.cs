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
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRpository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
        #region Private
        private readonly Dictionary<HireGroupDetailByColumn, Func<HireGroupDetail, object>> hireGroupDetailClause =
             new Dictionary<HireGroupDetailByColumn, Func<HireGroupDetail, object>>
                    {
                        { HireGroupDetailByColumn.HireGroupId, c => c.HireGroupId },
                        { HireGroupDetailByColumn.VehicleMakeId, c => c.VehicleMakeId }
                       
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRpository(IUnityContainer container)
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
        public IQueryable<HireGroupDetail> GetHireGroupDetails(TariffRateDetailRequest tariffRateDetailRequest)
        {
            int fromRow = (tariffRateDetailRequest.PageNo - 1) * tariffRateDetailRequest.PageSize;
            int toRow = tariffRateDetailRequest.PageSize;
            Expression<Func<HireGroupDetail, bool>> query =
                s =>
                    ((!(tariffRateDetailRequest.HireGroupId > 0) || s.HireGroupId == tariffRateDetailRequest.HireGroupId) &&
                     (!(tariffRateDetailRequest.VehicleMakeId > 0) ||
                      s.VehicleMakeId == tariffRateDetailRequest.VehicleMakeId) &&
                     (!(tariffRateDetailRequest.VehicleModelId > 0) ||
                      s.VehicleModelId == tariffRateDetailRequest.VehicleModelId)&&
                       (!(tariffRateDetailRequest.VehicleCategoryId > 0) ||
                      s.VehicleCategoryId == tariffRateDetailRequest.VehicleCategoryId));

            IEnumerable<HireGroupDetail> hireGroupDetails = tariffRateDetailRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(hireGroupDetailClause[tariffRateDetailRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(hireGroupDetailClause[tariffRateDetailRequest.TarrifTypeByOrder]).Skip(fromRow).Take(toRow).ToList();
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
