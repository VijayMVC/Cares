using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
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
        public override IQueryable<AddressType> GetAll()
        {
            return DbSet.Where(phoneTypes => phoneTypes.UserDomainKey == UserDomainKey);
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
        #endregion
    }
}
