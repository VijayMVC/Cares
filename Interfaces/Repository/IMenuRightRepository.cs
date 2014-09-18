using System.Linq;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    public interface IMenuRightRepository
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
