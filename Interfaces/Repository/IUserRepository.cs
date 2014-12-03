using Cares.Models.DomainModels;

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
