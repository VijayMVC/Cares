using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.MenuModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Menu Rights Service
    /// </summary>
    public sealed class MenuRightsService: IMenuRightsService
    {
        #region Private
        private readonly IMenuRightRepository menuRightRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRightsService(IMenuRightRepository menuRightRepository)
        {
            this.menuRightRepository = menuRightRepository;

        }
        #endregion

        #region Public
        /// <summary>
        /// Find Menu Items by Role ID
        /// </summary>
        public IQueryable<MenuRight> FindMenuItemsByRoleId(string roleId)
        {
 	       return menuRightRepository.GetMenuByRole(roleId);
        }

        #endregion
    }
}
