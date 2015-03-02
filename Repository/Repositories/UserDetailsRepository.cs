using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.IdentityModels;
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
        /// <summary>
        /// Saves user details provided while signup
        /// </summary>
        public void SaveUserDetails(User addedUser, Models.IdentityModels.ViewModels.RegisterViewModel model)
        {
            DbSet.Add(new UserDetail
            {
                CompanyName = model.CompanyName,
                AccountType = model.AccountType,
                Address = model.CompanyAddress,
                CountryName = model.CountryName,
                UserId = addedUser.Id
            });            
        }
    }
}
