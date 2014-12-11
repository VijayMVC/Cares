using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nrt Type Repository
    /// </summary>
    public sealed class NrtTypeRepository : BaseRepository<NrtType>, INrtTypeRepository
    {
        #region privte
        /// <summary>
        /// Nrt Type Orderby clause
        /// </summary>
        private readonly Dictionary<NrtTypeByColumn, Func<NrtType, object>> nrtTypeOrderByClause = new Dictionary<NrtTypeByColumn, Func<NrtType, object>>
                    {
                        {NrtTypeByColumn.Code, c => c.NrtTypeCode},
                        {NrtTypeByColumn.Name, d => d.NrtTypeName},
                        {NrtTypeByColumn.VehcileStatus, d => d.VehicleStatus.VehicleStatusId}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtType> DbSet
        {
            get
            {
                return db.NrtTypes;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Search Nrt Type
        /// </summary>
        public IEnumerable<NrtType> SearchNrtType(NrtTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<NrtType, bool>> query =
                nrtType =>
                    (string.IsNullOrEmpty(request.NrtTypeFilterText) || (nrtType.NrtTypeCode.Contains(request.NrtTypeFilterText)) ||
                     (nrtType.NrtTypeName.Contains(request.NrtTypeFilterText))) && (
                         (!request.VehhicleStatusId.HasValue || request.VehhicleStatusId == nrtType.VehicleStatusId)) && (nrtType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(nrtTypeOrderByClause[request.NrtTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(nrtTypeOrderByClause[request.NrtTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Get All nrtTypes for User Domain Key
        /// </summary>
        public override IEnumerable <NrtType> GetAll()
        {
            return DbSet.Where(nrtType => nrtType.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// NrtType Code validation check
        /// </summary>
        public bool IsNrtTypeCodeExists(NrtType nrtType)
        {
            return DbSet.Count(dBnrtType => dBnrtType.NrtTypeCode == nrtType.NrtTypeCode && dBnrtType.NrtTypeId != nrtType.NrtTypeId) > 0;
        }

        /// <summary>
        /// Get NrtType with Details
        /// </summary>
        public NrtType GetNrtTypeWithDetails(long nrtTypeId)
        {
            return DbSet.Include(nrtType => nrtType.VehicleStatus)
                .FirstOrDefault(nrtType => nrtType.NrtTypeId == nrtTypeId);
        }

        /// <summary>
        /// Association check b/n Vehicle Status and Nrt Type
        /// </summary>
        public bool IsVehicleStatusAssociatedWithNrtType(long vehicleStatusId)
        {
            return DbSet.Count(nrttype => nrttype.VehicleStatusId == vehicleStatusId) > 0;
        }
        #endregion
    }
}
