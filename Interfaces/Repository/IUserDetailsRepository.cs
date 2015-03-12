using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Interface for User Detail repository
    /// </summary>
    public interface IUserDetailsRepository : IBaseRepository<UserDetail, long>
    {
        /// <summary>
        /// Finds user details by user id
        /// </summary>
        UserDetail FindByUserId(string userId);

        /// <summary>
        /// Executes the procedure for creating default data
        /// </summary>
        void CopyUserDefaultData(string userId, long domainKey);
    }
}
