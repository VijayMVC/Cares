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
    /// Designation Grade Repository
    /// </summary>
    public sealed class DesignGradeRepository : BaseRepository<DesignGrade>, IDesignGradeRepository
    {
        #region privte
        /// <summary>
        /// Design Grade Orderby clause
        /// </summary>
        private readonly Dictionary<DesignGradeByColumn, Func<DesignGrade, object>> desigGradeOrderByClause = new Dictionary<DesignGradeByColumn, Func<DesignGrade, object>>
                    {
                        {DesignGradeByColumn.Code, d => d.DesigGradeCode},
                        {DesignGradeByColumn.Name, c => c.DesigGradeName},
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignGradeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DesignGrade> DbSet
        {
            get
            {
                return db.DesigGrades;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Designation Grade for User Domain Key
        /// </summary>
        public override IEnumerable<DesignGrade> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// Search Desig Grade
        /// </summary>
        public IEnumerable<DesignGrade> SearchDesigGrade(DesignGradeSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<DesignGrade, bool>> query =
                desigGrade =>
                    (string.IsNullOrEmpty(request.DesigGradeFilterText) ||
                     (desigGrade.DesigGradeCode.Contains(request.DesigGradeFilterText)) ||
                     (desigGrade.DesigGradeName.Contains(request.DesigGradeFilterText))) && (desigGrade.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(desigGradeOrderByClause[request.DesignGradeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(desigGradeOrderByClause[request.DesignGradeOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// To validate the code duplication check 
        /// </summary>
        public bool DesignGradeCodeDuplicationCheck(DesignGrade designGrade)
        {
            return
                DbSet.Count(
                    dBdesignGrade =>
                        dBdesignGrade.DesigGradeId != designGrade.DesigGradeId &&
                        dBdesignGrade.DesigGradeCode == designGrade.DesigGradeCode
                        && dBdesignGrade.UserDomainKey == UserDomainKey ) > 0;
        }

        #endregion
    }
}
