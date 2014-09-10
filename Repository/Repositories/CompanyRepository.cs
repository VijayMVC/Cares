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
    /// Company Repository
    /// </summary>
    public sealed class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        #region privte
        /// <summary>
        /// Company Orderby clause
        /// </summary>
        private readonly Dictionary<CompanyByColumn, Func<Company, object>> companyOrderByClause = new Dictionary<CompanyByColumn, Func<Company, object>>
                    {
                        {CompanyByColumn.OrgGroup, d => d.OrgGroupId !=null ? d.OrgGroup.OrgGroupName : string.Empty},
                        {CompanyByColumn.CompanyCode, c => c.CompanyCode},
                        {CompanyByColumn.CompanyName, d => d.CompanyName},
                        {CompanyByColumn.ParentCompany, d => d.ParentCompanyId !=null ? d.ParentCompany.CompanyName : string.Empty },
                        {CompanyByColumn.BusinessSegment, d => d.BusinessSegment != null ? d.BusinessSegment.BusinessSegmentName : string.Empty },
                        {CompanyByColumn.CompanyDescription, d => d.CompanyDescription}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Company> DbSet
        {
            get
            {
                return db.Companies;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Search Company
        /// </summary>
        public IEnumerable<Company> SearchCompany(CompanySearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Company, bool>> query =
                company =>
                    (string.IsNullOrEmpty(request.CompanyText) || (company.CompanyCode.Contains(request.CompanyText)) ||
                     (company.CompanyName.Contains(request.CompanyText))) && (
                         (!request.BusinessSegmentId.HasValue || request.BusinessSegmentId == company.BusinessSegmentId) &&
                         (!request.OrganizationGroupId.HasValue || request.OrganizationGroupId == company.OrgGroupId));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(companyOrderByClause[request.CompanyOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(companyOrderByClause[request.CompanyOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }
        /// <summary>
        /// Get All Companies for User Domain Key
        /// </summary>
        public override IEnumerable <Company> GetAll()
        {
            return DbSet.Where(company => company.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Get Company With Details
        /// </summary>
        public Company GetCompanyWithDetails(long id)
        {
            return DbSet.Include(company => company.OrgGroup)
                .Include(company => company.BusinessSegment)
                .Include(company => company.ParentCompany)
                .FirstOrDefault(fleetPool => fleetPool.UserDomainKey == UserDomainKey && fleetPool.CompanyId == id);
        }

        /// <summary>
        /// Comapny Code validation check
        /// </summary>
        public bool IsCompanyCodeExists(Company cmpCompany)
        {
            return DbSet.Count(company => company.CompanyCode.ToLower() == cmpCompany.CompanyCode.ToLower() && company.CompanyId != cmpCompany.CompanyId) > 0;
        }

        /// <summary>
        /// To identify if company is parent 
        /// </summary>
        public bool IsComapnyParent(long companyId)
        {
            return DbSet.Count( cmp => cmp.ParentCompanyId == companyId) > 0;
        }

        /// <summary>
        /// To identify if OrgGroup contains any company
        /// </summary>
        public bool IsOrgGroupContainCompany(long orgGroupId)
        {
            return DbSet.Count(cmp => cmp.OrgGroupId == orgGroupId) > 0;
        }
        #endregion
    }
}
