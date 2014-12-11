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
    /// Occupation Type Repository
    /// </summary>
    public sealed class OccupationTypeRepository : BaseRepository<OccupationType>, IOccupationTypeRepository
    {
        #region privte
        /// <summary>
        /// Occupation Type Orderby clause
        /// </summary>
        private readonly Dictionary<OccupationTypeByColumn, Func<OccupationType, object>> occupationTypeOrderByClause = new Dictionary<OccupationTypeByColumn, Func<OccupationType, object>>
                    {

                        {OccupationTypeByColumn.Code, c => c.OccupationTypeCode},
                        {OccupationTypeByColumn.Name, n => n.OccupationTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OccupationTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OccupationType> DbSet
        {
            get
            {
                return db.OccupationTypes;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Occupation Types for User Domain Key
        /// </summary>
        public override IEnumerable<OccupationType> GetAll()
        {
            return DbSet.Where(occupationType => occupationType.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Occupation Type
        /// </summary>
        public IEnumerable<OccupationType> SearchOccupationType(OccupationTypeSearchRequest request, out int rowCount)
        {

            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<OccupationType, bool>> query =
                occupationType =>
                    (string.IsNullOrEmpty(request.OccupationTypeCodeNameText) ||
                     (occupationType.OccupationTypeCode.Contains(request.OccupationTypeCodeNameText)) ||
                     (occupationType.OccupationTypeName.Contains(request.OccupationTypeCodeNameText))) && (occupationType.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(occupationTypeOrderByClause[request.OccupationTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(occupationTypeOrderByClause[request.OccupationTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList(); 
        }

        /// <summary>
        /// Self Occupation Type code check 
        /// </summary>
        public bool OccupationTypeCodeDuplicationCheck(OccupationType occupationType)
        {
            return
                DbSet.Count(
                    dboccupationType =>
                        dboccupationType.OccupationTypeId != occupationType.OccupationTypeId &&
                        dboccupationType.OccupationTypeCode == occupationType.OccupationTypeCode) > 0;
        }
        #endregion
    }
}
