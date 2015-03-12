using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.IdentityModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// User repository for User related functions
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<User> DbSet
        {
            get
            {
                return db.Users;
            }
        }

        #endregion
        #region

        /// <summary>
        /// To get the maximum user domain key
        /// </summary>
        public double GetMaxUserDomainKey()
        {
            return DbSet.Max(user => user.UserDomainKey);
        }
        /// <summary>
        /// Returns User by user Id
        /// </summary>
        public User FindUserById(string userId)
        {
            return DbSet.FirstOrDefault(user => user.Id == userId);
        }
        #endregion
    }
}
