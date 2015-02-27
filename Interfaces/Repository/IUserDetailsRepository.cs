using Cares.Models.Common;
using Cares.Models.IdentityModels;

namespace Cares.Interfaces.Repository
{
    public interface IUserDetailsRepository : IBaseRepository<UserDetail, long>
    {
        /// <summary>
        /// Saves user details provided while signup
        /// </summary>
        void SaveUserDetails(User addedUser, Models.IdentityModels.ViewModels.RegisterViewModel model);
    }
}
