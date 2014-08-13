using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Microsoft.Practices.Unity;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Address Repository
    /// </summary>
    public sealed class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Address> DbSet
        {
            get
            {
                return db.AddressList;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Address for User Domain Key
        /// </summary>
        public override IQueryable<Address> GetAll()
        {
            return DbSet.Where(addresslist => addresslist.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Find Address by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddressType Find(int id)
        {
            throw new System.NotImplementedException();
        }    
        #endregion
    }
}
