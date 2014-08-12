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
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRepository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupDetail> DbSet
        {
            get
            {
                return db.HireGroupDetails;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IQueryable<HireGroupDetail> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        /// <summary>
        /// Get Hire Group detail, based on filter criteria
        /// </summary>
        public IEnumerable<HireGroupDetail> GetHireGroupDetailsForTariffRate()
        {
            return DbSet.Where(h => h.UserDomainKey == UserDomainKey).Include(x => x.HireGroup); ;
        }

        /// <summary>
        /// Get Hire Group Detail By Hire Group Id
        /// </summary>
        public IEnumerable<HireGroupDetail> GetHireGroupDetailByHireGroupId(long hireGroupId)
        {
            return DbSet.Where(h => h.HireGroupId == hireGroupId);
        }
        #endregion
    }
}
