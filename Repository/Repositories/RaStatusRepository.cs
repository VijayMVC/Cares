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
    /// RA Status Repository
    /// </summary>
    public class RaStatusRepository : BaseRepository<RaStatus>, IRaStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RaStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaStatus> DbSet
        {
            get
            {
                return db.RaStatuses;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Ra Status for User Domain Key
        /// </summary>
        public override IEnumerable<RaStatus> GetAll()
        {
            return DbSet.Where(ra => ra.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find By Statu sKey
        /// </summary>
        /// <param name="statusKey"></param>
        /// <returns></returns>
        public RaStatus FindByStatusKey(short statusKey)
        {
            return DbSet.FirstOrDefault(ra => ra.UserDomainKey == UserDomainKey && ra.RaStatusKey == statusKey);
        }
        #endregion
    }
}
