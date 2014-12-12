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
    /// Business Partner Relationship Type Repository
    /// </summary>
    public sealed class BusinessPartnerRelationshipTypeRepository : BaseRepository<BusinessPartnerRelationshipType>, IBusinessPartnerRelationshipTypeRepository
    {
        #region privte
        /// <summary>
        /// Business Partner Relationship Type Orderby clause
        /// </summary>
        private readonly Dictionary<BusinessPartnerRelationTypeByColumn, Func<BusinessPartnerRelationshipType, object>> businessPartnerRelationTypeOrderByClause =
            new Dictionary<BusinessPartnerRelationTypeByColumn, Func<BusinessPartnerRelationshipType, object>>
                    {

                        {BusinessPartnerRelationTypeByColumn.Code, c => c.BusinessPartnerRelationshpTypeCode},
                        {BusinessPartnerRelationTypeByColumn.Name, n => n.BusinessPartnerRelationshipTypeName}
                 };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRelationshipTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerRelationshipType> DbSet
        {
            get
            {
                return db.BusinessPartnerRelationshipTypes;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Business Partner Relationship Types for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerRelationshipType> GetAll()
        {
            return DbSet.Where(businessPartnerRelationshipType => businessPartnerRelationshipType.UserDomainKey == UserDomainKey).ToList();
        }    

        /// <summary>
        /// Get Business Partner Relationship Type by Id
        /// </summary>
        public BusinessPartnerRelationshipType Find(int id)
        {
            return DbSet.FirstOrDefault(businessPartnerRelationshipType => businessPartnerRelationshipType.UserDomainKey==UserDomainKey);
        }

        /// <summary>
        /// Search Business Partner Relationship Type
        /// </summary>
        public IEnumerable<BusinessPartnerRelationshipType> SearchBusinessPartnerRelationshipType(
            BusinessPartnerRelationTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BusinessPartnerRelationshipType, bool>> query =
                businessPartnerRelationshipType =>
                    (string.IsNullOrEmpty(request.BusinessPartnerRelationTypeFilterText) ||
                     (businessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode.Contains(request.BusinessPartnerRelationTypeFilterText)) ||
                     (businessPartnerRelationshipType.BusinessPartnerRelationshipTypeName.
                     Contains(request.BusinessPartnerRelationTypeFilterText))) && (businessPartnerRelationshipType.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(businessPartnerRelationTypeOrderByClause[request.BusinessPartnerRelationTypeGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(businessPartnerRelationTypeOrderByClause[request.BusinessPartnerRelationTypeGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();  
        }

        /// <summary>
        /// Self code deuplication check
        /// </summary>
        public bool BusinessPartnerRelationshipTypeCodeDuplicationCheck(
            BusinessPartnerRelationshipType businessPartnerRelationshipType)
        {
            return DbSet.Count(
                dbBusinessPartnerRelationshipType =>
                    dbBusinessPartnerRelationshipType.BusinessPartnerRelationshipTypeId !=
                    businessPartnerRelationshipType.BusinessPartnerRelationshipTypeId &&
                    dbBusinessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode ==
                    businessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode
                    && dbBusinessPartnerRelationshipType.UserDomainKey == UserDomainKey ) > 0;
        }
        #endregion
    }
}
