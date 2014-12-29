using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cares.Commons;
using Cares.Implementation.Identity;
using Cares.Models.IdentityModels;
using Cares.Models.MenuModels;
using Cares.Web.ViewModels.Common;
using Microsoft.AspNet.Identity.Owin;

namespace Cares.Web.Controllers
{
    /// <summary>
    /// Menu Controller to load menu items
    /// </summary>
    public class MenuController : Controller
    {
        /// <summary>
        /// Menu Controller Constructure
        /// </summary>
// ReSharper disable once EmptyConstructor
        public MenuController()
        {
        }

        /// <summary>
        /// Load Menu items with respect to roles
        /// </summary>
        [ChildActionOnly]
        public ActionResult LoadMenu()
        {            
            User user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmailAsync(User.Identity.Name).Result;
            IList<MenuRight> menuItems;

            if (user.Roles == null || user.Roles.Count < 1)
                return View(new MenuViewModel());
            // ReSharper disable PossibleNullReferenceException
            if (user.Roles.Any(roles => roles.Name == CaresApplicationRoles.SystemAdministrator))
            {
                menuItems = user.Roles.FirstOrDefault(roles => roles.Name == CaresApplicationRoles.SystemAdministrator).MenuRights.ToList();
            }
            else if (user.Roles.Any(roles => roles.Name == CaresApplicationRoles.Admin))
            {
                menuItems = user.Roles.FirstOrDefault(roles => roles.Name == CaresApplicationRoles.Admin).MenuRights.ToList();
            }
            else
            {
                menuItems = user.Roles.FirstOrDefault().MenuRights.ToList();
            }
            // ReSharper disable once InconsistentNaming
            var menuVM = new MenuViewModel
            {
                MenuRights = menuItems,
                MenuHeaders = menuItems.Where(menu => menu.Menu.IsRootItem)
            };
            return View(menuVM);
        }
    }
}