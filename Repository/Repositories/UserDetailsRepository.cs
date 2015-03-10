using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public class UserDetailsRepository : BaseRepository<UserDetail>, IUserDetailsRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserDetailsRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<UserDetail> DbSet
        {
            get
            {
                return db.UserDetails;
            }
        }

        #endregion
        #region Public
        public UserDetail FindByUserId(string userId)
        {
            return DbSet.FirstOrDefault(userDetails => userDetails.UserId == userId);
        }
        #endregion
    }
}
