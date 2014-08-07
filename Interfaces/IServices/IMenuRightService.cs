using System.Linq;
using Cares.Models.MenuModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Interface for Menu Rights Service
    /// </summary>
    public interface IMenuRightsService
    {
        /// <summary>
        /// Find Menu item by Role
        /// </summary>        
        IQueryable<MenuRight> FindMenuItemsByRoleId(string roleId); 
    }
}
