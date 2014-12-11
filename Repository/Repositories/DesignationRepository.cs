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
    /// Designation Repository
    /// </summary>
    public sealed class DesignationRepository : BaseRepository<Designation>, IDesignationRepository
    {
        #region privte
        /// <summary>
        /// Designation Orderby clause
        /// </summary>
        private readonly Dictionary<DesignationByColumn, Func<Designation, object>> designationOrderByClause = new Dictionary<DesignationByColumn, Func<Designation, object>>
                    {
                        {DesignationByColumn.Code, d => d.DesignationCode},
                        {DesignationByColumn.Name, c => c.DesignationName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Designation> DbSet
        {
            get
            {
                return db.Designations;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Designation for User Domain Key
        /// </summary>
        public override IEnumerable<Designation> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Designation
        /// </summary>
        public IEnumerable<Designation> SearchDesignation(DesignationSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Designation, bool>> query =
                designation =>
                    (string.IsNullOrEmpty(request.DesignationFilterText) ||
                     (designation.DesignationCode.Contains(request.DesignationFilterText)) ||
                     (designation.DesignationName.Contains(request.DesignationFilterText))) && (designation.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(designationOrderByClause[request.DesignationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(designationOrderByClause[request.DesignationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Designation code duplication check
        /// </summary>
        public bool DoesDesignationCodeExist(Designation designation)
        {
            return (DbSet.Count(dBdesignation => dBdesignation.DesignationId != designation.DesignationId && dBdesignation.DesignationCode == designation.DesignationCode) > 0);  
        }
        #endregion
    }
}
