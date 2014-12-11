using System;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Workplace Type Repository
    /// </summary>
    public sealed class WorkplaceTypeRepository : BaseRepository<WorkPlaceType>, IWorkplaceTypeRepository
    {
        #region Private
        /// <summary>
        /// WorkplaceType Orderby clause
        /// </summary>
        private readonly Dictionary<WorkplaceTypeByColumn, Func<WorkPlaceType, object>> workplaceTypeOrderByClause = new Dictionary<WorkplaceTypeByColumn, Func<WorkPlaceType, object>>
                    {
                        {WorkplaceTypeByColumn.WorkplaceTypeCode, c => c.WorkPlaceTypeCode},
                        {WorkplaceTypeByColumn.WorkplaceTypeName, d => d.WorkPlaceTypeName},
                        {WorkplaceTypeByColumn.WorkplaceTypeDes, d => d.WorkPlaceTypeDescription  },
                        {WorkplaceTypeByColumn.WorkplaceNature, d => d.WorkPlaceTypeName },
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkplaceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<WorkPlaceType> DbSet
        {
            get
            {
                return db.WorkPlaceType;
            }
        }

        #endregion
        #region public

        /// <summary>
        /// Get all WorkPlace Types
        /// </summary>
        public override IEnumerable<WorkPlaceType> GetAll()
        {
            return DbSet.Where(workPlaceType => workPlaceType.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// Search WorkplaceType
        /// </summary>
        public IEnumerable<WorkPlaceType> SearchWorkplaceType(WorkplaceTypeSearchRequest workplaceTypeSearchRequest, out int rowCount)
        {
            int fromRow = (workplaceTypeSearchRequest.PageNo - 1) * workplaceTypeSearchRequest.PageSize;
            int toRow = workplaceTypeSearchRequest.PageSize;
            Expression<Func<WorkPlaceType, bool>> query =
                workPlaceType =>
                    (string.IsNullOrEmpty(workplaceTypeSearchRequest.WorkplaceTypeFilterText) || 
                    (workPlaceType.WorkPlaceTypeCode.Contains(workplaceTypeSearchRequest.WorkplaceTypeFilterText)) ||
                     (workPlaceType.WorkPlaceTypeName.Contains(workplaceTypeSearchRequest.WorkplaceTypeFilterText))) && (workPlaceType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return workplaceTypeSearchRequest.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(workplaceTypeOrderByClause[workplaceTypeSearchRequest.WorkplaceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(workplaceTypeOrderByClause[workplaceTypeSearchRequest.WorkplaceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// WorkPlaceType Code validation check
        /// </summary>
        public bool IsWorkPlaceTypeCodeExists(WorkPlaceType workPlaceType)
        {
            return DbSet.Count(dbworkPlaceType => dbworkPlaceType.WorkPlaceTypeCode.ToLower() == workPlaceType.WorkPlaceTypeCode.ToLower() && dbworkPlaceType.WorkPlaceTypeId != workPlaceType.WorkPlaceTypeId) > 0;

        }

        #endregion
    }
}
