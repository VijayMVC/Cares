using System.Linq;
using Cares.Models.MenuModels;

namespace Cares.Interfaces.Repository
{
    public interface IMenuRightRepository
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
