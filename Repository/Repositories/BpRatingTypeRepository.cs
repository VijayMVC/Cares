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
    /// Rating Type Repository
    /// </summary>
    public sealed class BpRatingTypeRepository : BaseRepository<BpRatingType>, IBpRatingTypeRepository
    {
        #region privte
        /// <summary>
        /// Rating Type Orderby clause
        /// </summary>
        private readonly Dictionary<RatingTypeByColumn, Func<BpRatingType, object>> ratingTypeOrderByClause = new Dictionary<RatingTypeByColumn, Func<BpRatingType, object>>
                    {
                        {RatingTypeByColumn.Code, d => d.BpRatingTypeCode },
                        {RatingTypeByColumn.Name, c => c.BpRatingTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpRatingTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BpRatingType> DbSet
        {
            get
            {
                return db.BpRatingTypes;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Rating Types for User Domain Key
        /// </summary>
        public override IEnumerable<BpRatingType> GetAll()
        {
            return DbSet.Where(bpRatingType => bpRatingType.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Rating Type
        /// </summary>
        public IEnumerable<BpRatingType> SearchRatingType(RatingTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BpRatingType, bool>> query =
                bpRatingType =>
                    (string.IsNullOrEmpty(request.RatingTypeFilterText) ||
                     (bpRatingType.BpRatingTypeCode.Contains(request.RatingTypeFilterText)) ||
                     (bpRatingType.BpRatingTypeName.Contains(request.RatingTypeFilterText)));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(ratingTypeOrderByClause[request.RatingTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(ratingTypeOrderByClause[request.RatingTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();  
        }

        /// <summary>
        /// seld-code duplication check
        /// </summary>
       public bool DoesRatingTypeCodeExist(BpRatingType rartingType)
        {
            return DbSet.Count(dBratingtype => dBratingtype.BpRatingTypeId != rartingType.BpRatingTypeId && dBratingtype.BpRatingTypeCode==rartingType.BpRatingTypeCode) > 0;
        }
        
        #endregion
    }
}
