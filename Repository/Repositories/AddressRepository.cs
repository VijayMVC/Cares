using System.Collections.Generic;
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
        public override IEnumerable<Address> GetAll()
        {
            return DbSet.Where(addresslist => addresslist.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Address by Id
        /// </summary>
        public Address Find(int id)
        {
            return DbSet.FirstOrDefault(address => address.UserDomainKey == UserDomainKey && address.AddressId==id);
        }

        /// <summary>
        /// To check the association of area with address
        /// </summary>
        public bool IsAreaAssociatedWithAddress(long areaId)
        {
            return DbSet.Count(address => address.UserDomainKey == UserDomainKey && address.AreaId == areaId) > 0;
        }
        #endregion
    }
}
