using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Service Type Repository
    /// </summary>
    public class ServiceTypeRepository : BaseRepository<ServiceType>, IServiceTypeRepository
    {
        #region privte
        /// <summary>
        /// Service Type Orderby clause
        /// </summary>
        private readonly Dictionary<ServiceTypeByColumn, Func<ServiceType, object>> serviceTypeOrderByClause = new Dictionary<ServiceTypeByColumn, Func<ServiceType, object>>
                    {
                        {ServiceTypeByColumn.Code, d => d.ServiceTypeCode},
                        {ServiceTypeByColumn.Name, c => c.ServiceTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceType> DbSet
        {
            get
            {
                return db.ServiceTypes;
            }
        }
        #endregion
        #region Public
        
        /// <summary>
        /// Get All Service Types for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceType> GetAll()
        {
            return DbSet.Where(serviceType => serviceType.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Service Type
        /// </summary>
        public IEnumerable<ServiceType> SearchServiceType(ServiceTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<ServiceType, bool>> query =
                serviceType =>
                    (string.IsNullOrEmpty(request.ServiceTypeFilterText) || (serviceType.ServiceTypeCode.Contains(request.ServiceTypeFilterText)) ||
                     (serviceType.ServiceTypeName.Contains(request.ServiceTypeFilterText))) && (serviceType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(serviceTypeOrderByClause[request.ServiceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(serviceTypeOrderByClause[request.ServiceTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Code duplication check
        /// </summary>
        public bool ServiceTypeCodeDuplicationCheck(ServiceType serviceType)
        {
            return
                DbSet.Count(
                    dBserviceType =>
                        dBserviceType.ServiceTypeId != serviceType.ServiceTypeId &&
                        dBserviceType.ServiceTypeCode == serviceType.ServiceTypeCode) > 0;
        }

        #endregion
    }
}
