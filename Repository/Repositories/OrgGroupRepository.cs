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
   
    public sealed class OrgGroupRepository : BaseRepository<OrgGroup>, IOrganizationGroupRepository
    {
        #region privte
        /// <summary>
        /// org group GroupOrderByClause
        /// </summary>
        private readonly Dictionary<OrgGroupByColumn, Func<OrgGroup, object>> orgGroupOrderByClause = new Dictionary<OrgGroupByColumn, Func<OrgGroup, object>>
                    {
                        {OrgGroupByColumn.OrgGroupCode, c => c.OrgGroupCode},
                        {OrgGroupByColumn.OrgGroupName, d => d.OrgGroupName},
                        {OrgGroupByColumn.OrgGroupDescription, d => d.OrgGroupDescription}
                    };
        #endregion
        #region public
        /// <summary>
        /// //Search org group
        /// </summary>
        public IEnumerable<OrgGroup> SearchOrgGroup(OrgGroupSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<OrgGroup, bool>> query =
              orgGroup =>
                      (string.IsNullOrEmpty(request.OrgGroupCode) || (orgGroup.OrgGroupCode.Contains(request.OrgGroupCode ) ))&& (
                      (string.IsNullOrEmpty(request.OrgGroupName) || ( orgGroup.OrgGroupName.Contains(request.OrgGroupName) ))    );
            rowCount = DbSet.Count(query);
           return request.IsAsc ?
               DbSet.Where(query)
                   .OrderBy(orgGroupOrderByClause[request.OrgGroupOrderBy])
                   .Skip(fromRow)
                   .Take(toRow)
                   .ToList() :
                DbSet.Where(query)
                   .OrderByDescending(orgGroupOrderByClause[request.OrgGroupOrderBy])
                   .Skip(fromRow)
                   .Take(toRow)
                   .ToList();
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrgGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OrgGroup> DbSet
        {
            get
            {
                return db.OrgGroups;
            }
        }

        #endregion
      
        
    }
}
