using System.Collections.Generic;
using Cares.Models.DomainModels;
using MenuRight = Cares.Web.Models.MenuRight;

namespace Cares.Web.ViewModels.RightsManagement
{
    /// <summary>
    /// Rights Management
    /// </summary>
    public class RightsManagementViewModel
    {
        public List<MenuRight> Rights { get; set; }
        
        public string SelectedRoleId { get; set; }

        public List<UserRole> Roles { get; set; }
    }
}