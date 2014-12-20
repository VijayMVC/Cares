using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.MenuModels;

namespace Cares.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, long>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
