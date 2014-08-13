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
        public override IQueryable<HireGroup> GetAll()
        {
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && (hireGroup.ParentHireGroupId == 0 || hireGroup.ParentHireGroupId == null));
        }

        /// <summary>
        /// Get Hire Groups By Code, Vehicle Make / Category / Model / Model Year
        /// </summary>
        public IEnumerable<HireGroup> GetByCodeAndVehicleInfo(string searchText)
        {
            return DbSet.Where(hg => (string.IsNullOrEmpty(searchText) ||
                                      (string.Format("{0}{1}", hg.HireGroupCode, hg.HireGroupName).Contains(searchText) ||
                                       hg.HireGroupDetails.Any(
                                           hgd =>
                                               (string.Format("{0}{1}", hgd.VehicleMake.VehicleMakeCode,
                                                   hgd.VehicleMake.VehicleMakeName).Contains(searchText)) ||
                                               (string.Format("{0}{1}", hgd.VehicleCategory.VehicleCategoryCode,
                                                    hgd.VehicleCategory.VehicleCategoryName).Contains(searchText)) ||
                                               (string.Format("{0}{1}", hgd.VehicleModel.VehicleModelCode,
                                                    hgd.VehicleModel.VehicleModelName).Contains(searchText)) ||
                                               (hgd.ModelYear.ToString(CultureInfo.InvariantCulture).Contains(searchText)))
                                      ))).OrderBy(hg => hg.HireGroupCode).ThenBy(hg => hg.HireGroupName).Take(10).ToList();
        }

        /// <summary>
        /// Get All Hire Group based on search crateria
        /// </summary>
        public HireGroupSearchResponse GetHireGroups(HireGroupSearchRequest hireGroupSearchRequest)
        {
            int fromRow = (hireGroupSearchRequest.PageNo - 1) * hireGroupSearchRequest.PageSize;
            int toRow = hireGroupSearchRequest.PageSize;
            Expression<Func<HireGroup, bool>> query =
                s =>
                    (hireGroupSearchRequest.CompanyId == null || s.Company.CompanyId == hireGroupSearchRequest.CompanyId) &&
                     (hireGroupSearchRequest.ParentHireGroupId == null ||
                      s.ParentHireGroupId == hireGroupSearchRequest.ParentHireGroupId);

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
            return DbSet.Where(hireGroup => hireGroup.UserDomainKey == UserDomainKey && hireGroup.IsParent);
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
            //LoadProperty<HireGroup>(hireGroup, "Company");
            LoadProperty(hireGroup, () => hireGroup.Company);
            LoadProperty(hireGroup, () => hireGroup.ParentHireGroup);
           
        }
        #endregion
    }
}
