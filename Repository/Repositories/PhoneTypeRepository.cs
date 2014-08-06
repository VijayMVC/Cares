using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Phone Type Repository
    /// </summary>
    public sealed class PhoneTypeRepository : BaseRepository<PhoneType>, IPhoneTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PhoneTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<PhoneType> DbSet
        {
            get
            {
                return db.PhoneTypes;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Phone Types for User Domain Key
        /// </summary>
        public override IQueryable<PhoneType> GetAll()
        {
            return DbSet.Where(phoneTypes => phoneTypes.UserDomainKey == UserDomainKey);
        }

        #endregion

        public PhoneType Find(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
