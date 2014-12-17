using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;

namespace Cares.Interfaces.Repository
{
    public interface   IUserRepository : IBaseRepository<User, long>
    {
        /// <summary>
        /// To get the maximum user domain key
        /// </summary>
        double GetMaxUserDomainKey();
    }
}
