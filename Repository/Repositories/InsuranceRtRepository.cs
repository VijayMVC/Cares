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
    /// Insurance Rate Repository
    /// </summary>
    public sealed class InsuranceRtRepository : BaseRepository<InsuranceRt>, IInsuranceRtRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRtRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceRt> DbSet
        {
            get
            {
                return db.InsuranceRts;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Insurance Rate for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceRt> GetAll()
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey).ToList();
        }

        public IEnumerable<InsuranceRt> GetInsuranceRtByInsuranceRtMainId(long insuranceRtMainId)
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey && insuranceRt.InsuranceRtMainId == insuranceRtMainId).ToList();
        }

        #endregion
    }
}
