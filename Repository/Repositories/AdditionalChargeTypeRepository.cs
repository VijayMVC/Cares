using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Additional Charge Type Repository
    /// </summary>
    public class AdditionalChargeTypeRepository : BaseRepository<AdditionalChargeType>, IAdditionalChargeTypeRepository
    {
        #region Private
        private readonly Dictionary<AdditionalChargeByColumn, Func<AdditionalChargeType, object>> additionalChargeClause =
             new Dictionary<AdditionalChargeByColumn, Func<AdditionalChargeType, object>>
                    {
                        { AdditionalChargeByColumn.Code, c => c.AdditionalChargeTypeCode },
                        { AdditionalChargeByColumn.Name, c => c.AdditionalChargeTypeName }
                    };

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AdditionalChargeType> DbSet
        {
            get
            {
                return db.AdditionalChargeTypes;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Additional Charge for User Domain Key
        /// </summary>
        public override IEnumerable<AdditionalChargeType> GetAll()
        {
            return DbSet.Where(addChrg => addChrg.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All Additional Charges based on search crateria
        /// </summary>
        public AdditionalChargeSearchResponse GetAdditionalCharges(AdditionalChargeSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            Expression<Func<AdditionalChargeType, bool>> query =
                s =>
                    ((string.IsNullOrEmpty(request.SearchString) ||
                      s.AdditionalChargeTypeCode.Contains(request.SearchString) ||
                      s.AdditionalChargeTypeName.Contains(request.SearchString)));

            IEnumerable<AdditionalChargeType> additionalChargeTypes = request.IsAsc ? DbSet.Where(query)
                                            .OrderBy(additionalChargeClause[request.AdditionalChargeOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(additionalChargeClause[request.AdditionalChargeOrderBy]).Skip(fromRow).Take(toRow).ToList();


            return new AdditionalChargeSearchResponse { AdditionalChargeTypes = additionalChargeTypes, TotalCount = DbSet.Count(query) };
        }

        #endregion
    }
}
