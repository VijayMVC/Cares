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
    /// Hire Group Up Grade Repository
    /// </summary>
    public class HireGroupUpGradeRepository : BaseRepository<HireGroupUpGrade>, IHireGroupUpGradeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupUpGradeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupUpGrade> DbSet
        {
            get
            {
                return db.HireGroupUpGrades;
            }
        }

        #endregion
        #region Public
        public IEnumerable<HireGroupUpGrade> FindByHireGroupId(long id)
        {
            return DbSet.Where(hgUGrade => hgUGrade.HireGroupId == id);
        }
        #endregion

       
    }
}
