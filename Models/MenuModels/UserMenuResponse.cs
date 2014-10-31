using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.MenuModels
{
    /// <summary>
    /// User Menu Response
    /// </summary>
    public class UserMenuResponse
    {
        public IList<MenuRight> MenuRights { get; set; }        

        public IList<Menu> Menus { get; set; }

        public IList<UserRole> Roles { get; set; }
    }
}
