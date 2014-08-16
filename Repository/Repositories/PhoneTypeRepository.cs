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
        public override IEnumerable<PhoneType> GetAll()
        {
            return DbSet.Where(phoneTypes => phoneTypes.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Find Phone Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhoneType Find(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
