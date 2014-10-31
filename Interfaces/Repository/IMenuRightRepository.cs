using System.Linq;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, long>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
