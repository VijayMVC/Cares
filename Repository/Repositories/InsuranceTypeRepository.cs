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
    /// Insurance Type Repository
    /// </summary>
    public sealed class InsuranceTypeRepository : BaseRepository<InsuranceType>, IInsuranceTypeRepository
    {
        #region privte
        /// <summary>
        /// Insurance Type Orderby clause
        /// </summary>
        private readonly Dictionary<InsuranceTypeByColumn, Func<InsuranceType, object>> insuranceTypeOrderByClause = new Dictionary<InsuranceTypeByColumn, Func<InsuranceType, object>>
                    {

                        {InsuranceTypeByColumn.Code, c => c.InsuranceTypeCode},
                        {InsuranceTypeByColumn.Name, n => n.InsuranceTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceType> DbSet
        {
            get
            {
                return db.InsuranceTypes;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Insurance Types for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceType> GetAll()
        {
            return DbSet.Where(insuranceType => insuranceType.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Insurance Type
        /// </summary>
        public IEnumerable<InsuranceType> SearchInsuranceType(InsuranceTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<InsuranceType, bool>> query =
                insuranceType =>
                    (string.IsNullOrEmpty(request.InsuranceTypeCodeNameText) ||
                     (insuranceType.InsuranceTypeCode.Contains(request.InsuranceTypeCodeNameText)) ||
                     (insuranceType.InsuranceTypeName.Contains(request.InsuranceTypeCodeNameText))) && (insuranceType.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(insuranceTypeOrderByClause[request.InsuranceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(insuranceTypeOrderByClause[request.InsuranceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// InsuranceType Self code duplication check
        /// </summary>
        public bool InsuranceTypeCodeDuplicationCheck(InsuranceType insuranceType)
        {
            return
                DbSet.Count(
                    dbinsuranceType =>
                        dbinsuranceType.InsuranceTypeCode == insuranceType.InsuranceTypeCode &&
                        dbinsuranceType.InsuranceTypeId != insuranceType.InsuranceTypeId) > 0;
        }
      
        #endregion

    }
}
