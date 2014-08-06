using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Standard Rate Repository
    /// </summary>
    public sealed class StandardRateRepository : BaseRepository<StandardRate>, IStandardRateRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardRate> DbSet
        {
            get
            {
                return db.StandardRates;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Standard Rates for User Domain Key
        /// </summary>
        public override IQueryable<StandardRate> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }
        public IEnumerable<StandardRate> GetStandardRateForTariffRate(long standardRtMainId)
        {
            return DbSet.Where(s => s.UserDomainKey == UserDomainKey && s.StandardRtMainId == standardRtMainId && s.ChildStandardRtId == 0);

        }
        /// <summary>
        /// Find by hire group and standard rate main id
        /// </summary>
        /// <param name="standardRtMainId"></param>
        /// <param name="hireGroupDetailId"></param>
        /// <returns></returns>
        public IEnumerable<StandardRate> FindByHireGroupId(long standardRtMainId, long hireGroupDetailId)
        {
            return DbSet.Where(s => s.UserDomainKey == UserDomainKey && s.StandardRtMainId == standardRtMainId && s.ChildStandardRtId == 0 && s.HireGroupDetailId == hireGroupDetailId);

        }
        #endregion
    }
}
