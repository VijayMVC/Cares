using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Credit Limit Repository
    /// </summary>
    public sealed class CreditLimitRepository : BaseRepository<CreditLimit>, ICreditLimitRepository
    {
        #region Privte
        /// <summary>
        /// Credit Limit Orderby clause
        /// </summary>
        private readonly Dictionary<CreditLimitByColumn, Func<CreditLimit, object>> creditLimitOrderByClause = new Dictionary<CreditLimitByColumn, Func<CreditLimit, object>>
                    {

                        {CreditLimitByColumn.SubType, c => c.BpSubType.BusinessPartnerSubTypeId},
                        {CreditLimitByColumn.Rating, n => n.BpRatingType.BpRatingTypeCode},
                        {CreditLimitByColumn.CreditLimit, d=> d.StandardCreditLimit}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CreditLimitRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<CreditLimit> DbSet
        {
            get
            {
                return db.CreditLimits;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Associatin check of cradit limit with rating type
        /// </summary>
        public bool IsRatingTypeAssociatedWithCreditLimit(long ratingTypeId)
        {
            return DbSet.Count(creidtlimit =>creidtlimit.UserDomainKey==UserDomainKey &&  creidtlimit.BpRatingTypeId == ratingTypeId) > 0;
        }

        /// <summary>
        /// Association check of Business Partner Sub Type and credit limit
        /// </summary>
        public bool IsBusinessPartnerSubTypeAssociatedWithCreditLimit(long businessPartnerSubTypeId)
        {
            return DbSet.Count(creidtlimit =>creidtlimit.UserDomainKey==UserDomainKey &&  creidtlimit.BpSubTypeId == businessPartnerSubTypeId) > 0;            
        }

        /// <summary>
        /// Search Credit Limit
        /// </summary>
        public IEnumerable<CreditLimit> SearchCreditLimit(CreditLimitSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<CreditLimit, bool>> query =
                creditLimit =>
                    (!request.BpSubTypeId.HasValue || request.BpSubTypeId == creditLimit.BpSubTypeId) &&
                    (!request.RatingTypeId.HasValue || request.RatingTypeId == creditLimit.BpRatingTypeId) && (creditLimit.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(creditLimitOrderByClause[request.CreditLimitOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(creditLimitOrderByClause[request.CreditLimitOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Get detail object of Credit Limit
        /// </summary>
        public CreditLimit GetCreditLimitWithDetail(long creditLimitId)
        {
            return DbSet.Include(creditLimit => creditLimit.BpSubType)
                .Include(creditLimit => creditLimit.BpRatingType)
                .FirstOrDefault(creditLimit => creditLimit.CreditLimitId == creditLimitId && creditLimit.UserDomainKey==UserDomainKey); 
        }

      
        #endregion
    }
}
