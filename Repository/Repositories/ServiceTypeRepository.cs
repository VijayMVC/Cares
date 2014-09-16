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
    /// Service Type Repository
    /// </summary>
    public class ServiceTypeRepository : BaseRepository<ServiceType>, IServiceTypeRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceType> DbSet
        {
            get
            {
                return db.ServiceTypes;
            }
        }
        #endregion

        #region Public
        
        /// <summary>
        /// Get All ServiceT ype for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceType> GetAll()
        {
            return DbSet.Where(serviceType => serviceType.UserDomainKey == UserDomainKey).ToList();
        }



        #endregion
    }
}
