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
    /// Business Partner Main Type Repository
    /// </summary>
    public sealed class BpMainTypeRepository : BaseRepository<BusinessPartnerMainType>, IBpMainTypeRepository
    {
        #region privte
        /// <summary>
        /// Bp Main Type Orderby clause for sorting 
        /// </summary>
        private readonly Dictionary<BpMainTypeByColumn, Func<BusinessPartnerMainType, object>> bpMainTypeOrderByClause = new Dictionary<BpMainTypeByColumn, Func<BusinessPartnerMainType, object>>
                    {
                        {BpMainTypeByColumn.Code, d => d.BusinessPartnerMainTypeCode},
                        {BpMainTypeByColumn.Name, c => c.BusinessPartnerMainTypeName}
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpMainTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerMainType> DbSet
        {
            get
            {
                return db.BusinessPartnerMainTypes;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Business Partner Main Type for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerMainType> GetAll()
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Business Partner Main Type By Id
        /// </summary>
        public BusinessPartnerMainType Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Search Business Partner Main Type
        /// </summary>
        public IEnumerable<BusinessPartnerMainType> SearchBpMainType(BpMainTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BusinessPartnerMainType, bool>> query =
                bpMainType =>
                    (string.IsNullOrEmpty(request.BpMainTypeFilterText) ||
                     (bpMainType.BusinessPartnerMainTypeName.Contains(request.BpMainTypeFilterText)) ||
                     (bpMainType.BusinessPartnerMainTypeCode.Contains(request.BpMainTypeFilterText))) && (bpMainType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(bpMainTypeOrderByClause[request.BpMainTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(bpMainTypeOrderByClause[request.BpMainTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        ///Business Partner Main Type Code duplication check 
        /// </summary>
        public bool DoesBpMainTypeCodeExists(BusinessPartnerMainType businessPartnerMainType)
        {
            return
                DbSet.Count(
                    bpMainType =>
                        bpMainType.BusinessPartnerMainTypeCode == businessPartnerMainType.BusinessPartnerMainTypeCode &&
                        bpMainType.BusinessPartnerMainTypeId != businessPartnerMainType.BusinessPartnerMainTypeId) > 0;
        }

        #endregion
    }
}
