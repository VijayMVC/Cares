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
    /// Workplace Repository
    /// </summary>
    public sealed class WorkplaceRepository : BaseRepository<WorkPlace>, IWorkplaceRepository
    {
        #region Private
        /// <summary>
        /// To sort the Workplace Data
        /// </summary>
        private readonly Dictionary<WorkplaceByColumn, Func<WorkPlace, object>> workPlaceOrderByClause = new Dictionary<WorkplaceByColumn, Func<WorkPlace, object>>
                    {
                        { WorkplaceByColumn.WorkplaceCode, c => c.WorkPlaceCode },
                        { WorkplaceByColumn.WorkplaceName, c => c.WorkPlaceName },
                        { WorkplaceByColumn.Description, c => c.WorkPlaceDescription },
                        { WorkplaceByColumn.WorkplaceType, c => c.WorkPlaceType },
                        { WorkplaceByColumn.Company, c => c.WorkLocation.CompanyId },
                        { WorkplaceByColumn.WorkLocation, c => c.WorkLocation.WorkLocationId },
                        { WorkplaceByColumn.ParentWorkPlace, c => c.ParentWorkPlaceId },
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkplaceRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<WorkPlace> DbSet
        {
            get
            {
                return db.WorkPlaces;
            }
        }

        #endregion
        #region public

        /// <summary>
        /// Search Workplace
        /// </summary>
        public IEnumerable<WorkPlace> SearchWorkplace(WorkplaceSearchRequest request, out int rowCount)
        {

            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<WorkPlace, bool>> query =
                workplace =>
                    (string.IsNullOrEmpty(request.WorkplaceFilterText) ||
                     (workplace.WorkPlaceCode.Contains(request.WorkplaceFilterText)) ||
                     (workplace.WorkPlaceName.Contains(request.WorkplaceFilterText)))  &&
                    (!request.CompanyId.HasValue || request.CompanyId == workplace.WorkLocation.CompanyId) &&
                    (!request.WorkplaceTypeId.HasValue || request.WorkplaceTypeId == workplace.WorkPlaceTypeId);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(workPlaceOrderByClause[request.WorkplaceOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(workPlaceOrderByClause[request.WorkplaceOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList(); 
        }

        /// <summary>
        /// Get Workplace With Details 
        /// </summary>
        public WorkPlace GetWorkplaceWithDetails(long id)
        {
            return DbSet.Include(opp => opp.WorkLocation)
                .Include(opp => opp.WorkLocation.Company)
                .Include(opp => opp.OperationsWorkPlaces)
                .Include(opp => opp.WorkPlaceType)
                .Include(opp => opp.ParentWorkPlace)
                .FirstOrDefault(opp => opp.WorkPlaceId == id);
        }

        /// <summary>
        /// Get All Workplaces
        /// </summary>
        public override IEnumerable<WorkPlace> GetAll()
        {
            return DbSet.Where(workPlace => workPlace.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Check if workplace is parrent of some other workplace
        /// </summary>
        /// <returns></returns>
        public bool IsWorkPalceParrent(long workplaceId)
        {
           return DbSet.Count(workplace => workplace.ParentWorkPlaceId == workplaceId)>0;
        }

        /// <summary>
        /// To check the availbility of workplace code
        /// </summary>
        public bool DoesWorkPlaceCodeExists(WorkPlace workplace)
        {
            return (DbSet.Count(dbWorkplace => dbWorkplace.WorkPlaceCode == workplace.WorkPlaceCode && dbWorkplace.WorkPlaceId != workplace.WorkPlaceId) > 0);
        }
        #endregion
    }
}
