using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Discount Sub Type Repository Model
    /// </summary>
    public sealed class DiscountSubTypeRepository : BaseRepository<DiscountSubType>, IDiscountSubTypeRepository
    {
        #region privte
        /// <summary>
        /// Discount SubT ype Orderby clause
        /// </summary>
        private readonly Dictionary<DiscountSubTypeByColumn, Func<DiscountSubType, object>> discountSubTypeOrderByClause = new Dictionary<DiscountSubTypeByColumn, Func<DiscountSubType, object>>
                    {
                        {DiscountSubTypeByColumn.Code, d => d.DiscountSubTypeCode},
                        {DiscountSubTypeByColumn.Name, c => c.DiscountSubTypeName},
                        {DiscountSubTypeByColumn.DiscountType, d => d.DiscountType.DiscountTypeId}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountSubTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DiscountSubType> DbSet
        {
            get
            {
                return db.DiscountSubTypes;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Find Discount Sub Type
        /// </summary>
        public DiscountSubType Find(int id)
        {
            return DbSet.FirstOrDefault(discount => discount.DiscountSubTypeId==id && discount.UserDomainKey==UserDomainKey);
        }

        /// <summary>
        /// Search Discount Sub Type
        /// </summary>
        public IEnumerable<DiscountSubType> SearchDiscountSubType(DiscountSubTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<DiscountSubType, bool>> query =
                discountsubType =>
                    (string.IsNullOrEmpty(request.DiscountSubTypeFilterText) ||
                     (discountsubType.DiscountSubTypeCode.Contains(request.DiscountSubTypeFilterText)) ||
                     (discountsubType.DiscountSubTypeName.Contains(request.DiscountSubTypeFilterText))) && (
                         (!request.DiscountTypeId.HasValue || request.DiscountTypeId == discountsubType.DiscountTypeId)) && (discountsubType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(discountSubTypeOrderByClause[request.DiscountSubTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(discountSubTypeOrderByClause[request.DiscountSubTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Duplicate Code Check
        /// </summary>
        public bool DoesDiscountSubTypeCodeExist(DiscountSubType discountSubType)
        {
            return
                DbSet.Count(
                    dBDiscountSubType => dBDiscountSubType.UserDomainKey==UserDomainKey && 
                        dBDiscountSubType.DiscountSubTypeId != discountSubType.DiscountSubTypeId &&  dBDiscountSubType.DiscountSubTypeCode == discountSubType.DiscountSubTypeCode) > 0;
        }

        /// <summary>
        /// Associatoin with discount Type validatoin before the deletion of discount type
        /// </summary>
        public bool IsDiscountSubTypeAssociatedWithDiscountType(long discountTypeId)
        {
            return DbSet.Count(dBDiscountSubType => dBDiscountSubType.DiscountTypeId == discountTypeId && dBDiscountSubType.UserDomainKey == UserDomainKey) > 0;
        }

        /// <summary>
        /// Get Discount Sub Type Details
        /// </summary>
        public DiscountSubType GetDiscountSubTypeWithDetails(long discountTypeId)
        {
            return DbSet.Include(company => company.DiscountType)
                .FirstOrDefault(fleetPool => fleetPool.DiscountSubTypeId == discountTypeId && fleetPool.UserDomainKey==UserDomainKey);
        }
        #endregion

    }
}
