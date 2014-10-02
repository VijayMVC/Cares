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
    /// Business Partner SubType Repository
    /// </summary>
    public sealed class BusinessPartnerSubTypeRepository : BaseRepository<BusinessPartnerSubType>, IBusinessPartnerSubTypeRepository
    {
        #region Private
        /// <summary>
        /// Business Partner Sub Type Orderby clause
        /// </summary>
        private readonly Dictionary<BusinessPartnerSubTypeByColumn, Func<BusinessPartnerSubType, object>> businessPartnerSubTypeOrderByClause =
            new Dictionary<BusinessPartnerSubTypeByColumn, Func<BusinessPartnerSubType, object>>
                    {

                        {BusinessPartnerSubTypeByColumn.Code, c => c.BusinessPartnerSubTypeCode},
                        {BusinessPartnerSubTypeByColumn.Name, n => n.BusinessPartnerSubTypeName},
                        {BusinessPartnerSubTypeByColumn.BpMainType, n => n.BusinessPartnerMainType.BusinessPartnerMainTypeId}

                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerSubTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerSubType> DbSet
        {
            get
            {
                return db.BusinessPartnerSubTypes;
            }
        }

        #endregion
        #region Public
        
        /// <summary>
        /// Get All Business Partner Sub Types
        /// </summary>
        /// <returns></returns>
       public override IEnumerable<BusinessPartnerSubType> GetAll()
        {
            return DbSet.Where(businessPartnerSubType => businessPartnerSubType.UserDomainKey == UserDomainKey).ToList();
        }
      
       
        /// <summary>
        /// Get Business Partner SubType by Id
        /// </summary>
        public BusinessPartnerSubType Find(int id)
        {
           return DbSet.Find(id);
        }

        /// <summary>
        /// Search Business Partner Sub Type
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> SearchBusinessPartnerSubType(BusinessPartnerSubTypeSearchRequest request,
            out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BusinessPartnerSubType, bool>> query =
                businessPartnerSubType =>
                    (string.IsNullOrEmpty(request.BusinessPartnerSubTypeCodeNameText) ||
                     (businessPartnerSubType.BusinessPartnerSubTypeCode.Contains(request.BusinessPartnerSubTypeCodeNameText)) ||
                     (businessPartnerSubType.BusinessPartnerSubTypeName.Contains(request.BusinessPartnerSubTypeCodeNameText))) &&
                    (!request.BusinessPartnerMainTypeId.HasValue || request.BusinessPartnerMainTypeId == businessPartnerSubType.BusinessPartnerMainTypeId);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(businessPartnerSubTypeOrderByClause[request.BusinessPartnerSubTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(businessPartnerSubTypeOrderByClause[request.BusinessPartnerSubTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Business Partner Sub Type Self code duplication check
        /// </summary>
        public bool BusinessPartnerSubTypeCodeDuplicationCheck(BusinessPartnerSubType businessPartnerSubType)
        {
            return
                DbSet.Count(
                    bpSubType =>
                        bpSubType.BusinessPartnerSubTypeId != businessPartnerSubType.BusinessPartnerSubTypeId &&
                        bpSubType.BusinessPartnerSubTypeCode == businessPartnerSubType.BusinessPartnerSubTypeCode) > 0;
        }


        /// <summary>
        /// Load the detail object of Business Partner SubType
        /// </summary>
        public BusinessPartnerSubType LoadBusinessPartnerSubTypeWithDetail(long businessPartnerSubTypeId)
        {
            return DbSet.Include(businessPartnerSubType => businessPartnerSubType.BusinessPartnerMainType)
               .FirstOrDefault(businessPartnerSubType => businessPartnerSubType.BusinessPartnerSubTypeId == businessPartnerSubTypeId);
        }
        #endregion
    }
}
