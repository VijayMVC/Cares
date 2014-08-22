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
    /// Service Rate Main Repository
    /// </summary>
    public class ServiceRtMainRepository : BaseRepository<ServiceRtMain>, IServiceRtMainRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceRtMain> DbSet
        {
            get
            {
                return db.ServiceRtMains;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Service Rate Main for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceRtMain> GetAll()
        {
            return DbSet.Where(serviceRtMain => serviceRtMain.UserDomainKey == UserDomainKey).ToList();
        }



        #endregion
    }
}
