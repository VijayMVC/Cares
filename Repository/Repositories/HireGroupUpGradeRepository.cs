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

        /// <summary>
        /// Find By Hire Group Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<HireGroupUpGrade> FindByHireGroupId(long id)
        {
            return DbSet.Where(hgUGrade => hgUGrade.HireGroupId == id && hgUGrade.UserDomainKey == UserDomainKey).ToList();

        }

        /// <summary>
        /// Find By Allowed Hire Group Id
        /// </summary>
        /// <param name="allowedHireGroupId"></param>
        /// <returns></returns>
        public IEnumerable<HireGroupUpGrade> FindByAllowedHireGroupId(long allowedHireGroupId)
        {
            return DbSet.Where(hgUGrade => hgUGrade.AllowedHireGroupId == allowedHireGroupId && hgUGrade.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion


    }
}
