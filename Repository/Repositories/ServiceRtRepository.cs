using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Service Rate Repository
    /// </summary>
    public class ServiceRtRepository : BaseRepository<ServiceRt>, IServiceRtRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceRt> DbSet
        {
            get
            {
                return db.ServiceRts;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Service Rate for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceRt> GetAll()
        {
            return DbSet.Where(serviceRt => serviceRt.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Service Rate By Service Rate Main Id
        /// </summary>
        /// <param name="serviceRtMainId"></param>
        /// <returns></returns>
        public IEnumerable<ServiceRt> GetServiceRtByServiceRtMainId(long serviceRtMainId)
        {
            return DbSet.Where(serviceRt => serviceRt.UserDomainKey == UserDomainKey && serviceRt.ServiceRtMainId == serviceRtMainId).ToList();
        }

        #endregion
    }
}
