using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Hire Group Repository
    /// </summary>
    public sealed class HireGroupRepository : BaseRepository<HireGroup>, IHireGroupRepository
    {
        #region Private
        private readonly Dictionary<HireGroupByColumn, Func<HireGroup, object>> hireGroupClause =
             new Dictionary<HireGroupByColumn, Func<HireGroup, object>>
                    {
                        { HireGroupByColumn.HireGroupCode, c => c.HireGroupCode },
                        { HireGroupByColumn.HireGroupName, c => c.HireGroupName },
                        { HireGroupByColumn.ParentHireGroup, c => c.ParentHireGroupId }
                       
                    };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroup> DbSet
        {
            get
            {
                return db.HireGroups;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Hire Groups 
        /// </summary>
        public override IEnumerable<HireGroup> GetAll()
        {
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && (hireGroup.ParentHireGroupId == 0 || hireGroup.ParentHireGroupId == null)).ToList();
        }

        /// <summary>
        /// Get All Hire Group based on search crateria
        /// </summary>
        public HireGroupSearchResponse GetHireGroups(HireGroupSearchRequest hireGroupSearchRequest)
        {
            int fromRow = (hireGroupSearchRequest.PageNo - 1) * hireGroupSearchRequest.PageSize;
            int toRow = hireGroupSearchRequest.PageSize;
            Expression<Func<HireGroup, bool>> query =
                s => (string.IsNullOrEmpty(hireGroupSearchRequest.SearchString) || s.HireGroupCode.Contains(hireGroupSearchRequest.SearchString) || s.HireGroupName.Contains(hireGroupSearchRequest.SearchString)) &&
                    (hireGroupSearchRequest.CompanyId == null || s.Company.CompanyId == hireGroupSearchRequest.CompanyId) &&
                     (hireGroupSearchRequest.ParentHireGroupId == null ||
                      s.ParentHireGroupId == hireGroupSearchRequest.ParentHireGroupId && s.UserDomainKey == UserDomainKey);

            IEnumerable<HireGroup> hireGroups = hireGroupSearchRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(hireGroupClause[hireGroupSearchRequest.HireGroupOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(hireGroupClause[hireGroupSearchRequest.HireGroupOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new HireGroupSearchResponse { HireGroups = hireGroups, TotalCount = DbSet.Count(query) };
        }

        /// <summary>
        /// Get All Parent Hire Groups 
        /// </summary>
        public IEnumerable<HireGroup> GetParentHireGroups()
        {
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && hireGroup.IsParent).ToList();
        }

        /// <summary>
        /// Get Hire Groups that are not parent hire groups 
        /// </summary>
        public IEnumerable<HireGroup> GetHireGroupList()
        {
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && !hireGroup.IsParent);
        }

        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(HireGroup hireGroup)
        {
            LoadProperty(hireGroup, () => hireGroup.Company);
            //LoadProperty(hireGroup, () => hireGroup.ParentHireGroup);

        }

        /// <summary>
        /// Hire Group Code validation check
        /// </summary>
        public bool IsHireGroupCodeExists(string hireGroupCode, long hireGroupId)
        {
            return DbSet.Count(hg => hg.HireGroupCode.ToLower() == hireGroupCode.ToLower() && hg.UserDomainKey == UserDomainKey &
                hg.HireGroupId != hireGroupId) > 0;
        }
        #endregion
    }
}
