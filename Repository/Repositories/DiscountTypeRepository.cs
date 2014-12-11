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
    public sealed class DiscountTypeRepository : BaseRepository<DiscountType>, IDiscountTypeRepository
    {
        #region privte
        /// <summary>
        ///  Discount Type Orderby clause
        /// </summary>
        private readonly Dictionary<DiscountTypeByColumn, Func<DiscountType, object>> discountTypeByClause = new Dictionary<DiscountTypeByColumn, Func<DiscountType, object>>
                    {
                        {DiscountTypeByColumn.Code, d => d.DiscountTypeCode},
                        {DiscountTypeByColumn.Name, c => c.DiscountTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DiscountType> DbSet
        {
            get
            {
                return db.DiscountTypes;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get All Discount Types
        /// </summary>
        public override IEnumerable<DiscountType> GetAll()
        {
            return DbSet.Where(workPlace => workPlace.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Discount Type
        /// </summary>
        public DiscountType Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Search Discount Type
        /// </summary>
        public IEnumerable<DiscountType> SearchDiscountType(DiscountTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<DiscountType, bool>> query =
                discountType =>
                    (string.IsNullOrEmpty(request.DiscountTypeFilterText) ||
                     (discountType.DiscountTypeCode.Contains(request.DiscountTypeFilterText)) ||
                     (discountType.DiscountTypeName.Contains(request.DiscountTypeFilterText))) && (discountType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(discountTypeByClause[request.DiscountTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(discountTypeByClause[request.DiscountTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Code Duplication Check 
        /// </summary>
        public bool DoesDiscountTypeCodeExist(DiscountType discountType)
        {
            return DbSet.Count(
                dBdiscountType =>
                    dBdiscountType.DiscountTypeCode == discountType.DiscountTypeCode &&
                    dBdiscountType.DiscountTypeId != discountType.DiscountTypeId) > 0;
        }
        #endregion

    }
}
