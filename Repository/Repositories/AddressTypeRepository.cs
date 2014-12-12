using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Cares.Interfaces.Repository;
using Microsoft.Practices.Unity;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Address Type Repository
    /// </summary>
    public sealed class AddressTypeRepository : BaseRepository<AddressType>, IAddressTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AddressType> DbSet
        {
            get
            {
                return db.AddressTypes;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Address Types for User Domain Key
        /// </summary>
        public override IEnumerable<AddressType> GetAll()
        {
            return DbSet.Where(phoneTypes => phoneTypes.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Find Address Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddressType Find(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get Address Type Id using Address Type Key 
        /// </summary>    
        public short GetAddressTypeIdByAddressTypeKey(long addressTypeKey)
        {
            return DbSet.Where(addresstype => addresstype.AddressTypeKey == addressTypeKey && addresstype.UserDomainKey == UserDomainKey)
                .Select(addresstype => addresstype.AddressTypeId).FirstOrDefault();
        }

        #endregion
    }
}
