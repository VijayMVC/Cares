using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Web.ViewModels.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Cares.Web.Controllers
{
    /// <summary>
    /// Menu Controller to load menu items
    /// </summary>
    public class MenuController : Controller
    {
        private readonly IMenuRightsService menuRightService;
        
        /// <summary>
        /// Menu Controller Constructure
        /// </summary>
        public MenuController(IMenuRightsService menuRightService)
        {
            this.menuRightService = menuRightService;
        }

        /// <summary>
        /// User Manger for logged in user credientals
        /// </summary>
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Load Menu items with respect to roles
        /// </summary>
        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            if (Session["MenuItems"] != null)
            {
                return View(Session["MenuItems"] as MenuViewModel);
            }

            MenuViewModel menuVM = new MenuViewModel();
            string userName = HttpContext.User.Identity.Name;
            if (!String.IsNullOrEmpty(userName))
            {
                User userResult = UserManager.FindByEmail(userName);
                IList<UserRole> roles = userResult.Roles.ToList();
                if (roles.Count > 0)
                {
                    IEnumerable<MenuRight> menuItems = menuRightService.FindMenuItemsByRoleId(roles[0].Id).ToList(); //"73953B69-8C5A-458F-A75B-399EF9E16371"

                    menuVM = new MenuViewModel
                    {
                        MenuRights = menuItems,
                        MenuHeaders = menuItems.Where(x => x.Menu.IsRootItem)
                    };
                }
            }

            Session["MenuItems"] = menuVM;
            return View(menuVM);
        }
    }
}