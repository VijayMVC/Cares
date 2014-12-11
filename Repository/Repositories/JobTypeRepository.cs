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
    /// Job Type Repository
    /// </summary>
    public sealed class JobTypeRepository : BaseRepository<JobType>, IJobTypeRepository
    {
        #region privte
        /// <summary>
        /// Job Type Orderby clause for sorting 
        /// </summary>
        private readonly Dictionary<JobTypeByColumn, Func<JobType, object>> jobTypeOrderByClause = new Dictionary<JobTypeByColumn, Func<JobType, object>>
                    {
                        {JobTypeByColumn.Code, d => d.JobTypeCode},
                        {JobTypeByColumn.Name, c => c.JobTypeName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public JobTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<JobType> DbSet
        {
            get
            {
                return db.JobTypes;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Job Types for User Domain Key
        /// </summary>
        public override IEnumerable<JobType> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Job Type
        /// </summary>
        public IEnumerable<JobType> SearchJobType(JobTypeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<JobType, bool>> query =
                jobType =>
                    (string.IsNullOrEmpty(request.JobTypeFilterText) ||
                     (jobType.JobTypeCode.Contains(request.JobTypeFilterText)) ||
                     (jobType.JobTypeName.Contains(request.JobTypeFilterText))) && (jobType.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(jobTypeOrderByClause[request.JobTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(jobTypeOrderByClause[request.JobTypeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Code Duplication Check
        /// </summary>
        public bool DoesJobTypeCodeExists(JobType jobType)
        {
            return
                DbSet.Count(
                    dBjobtype =>
                        dBjobtype.JobTypeId != jobType.JobTypeId && jobType.JobTypeCode == dBjobtype.JobTypeCode) > 0;
        }

        #endregion
    }
}
