using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Designation Grade Repository
    /// </summary>
    public sealed class DesigGradeRepository : BaseRepository<DesigGrade>, IDesigGradeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesigGradeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DesigGrade> DbSet
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
        public override IEnumerable<DesigGrade> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
