using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;

namespace Cares.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Private

        
        [Dependency]
        public IMenuRightsService MenuRightService { get; set; }

        #endregion

        #region Protected
        // GET: Base
        protected override async void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            SetUserDetail();
        }

        #endregion

        #region Public

        /// <summary>
        /// Set User Detail In Session
        /// </summary>
        private void SetUserDetail()
        {
            if ((Session["LoggedInUser"] != null && Session["LoggedInUser"] != "") && (Session["UserDomainKey"] != null && Session["UserDomainKey"] != ""))
            {
                return;
            }

            Session["LoggedInUser"] = Session["UserDomainKey"] = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                User result = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);

                Session["LoggedInUser"] = result.UserName;
                Session["UserDomainKey"] = result.UserDomainKey;

                IList<UserRole> aspUserroles = result.Roles.ToList();
                // If No role assigned
                if (aspUserroles.Count == 0)
                {
                    return;
                }

                Session["Role"] = HttpContext.GetOwinContext().Get<ApplicationRoleManager>().FindById(aspUserroles[0].Id).Name;

                IEnumerable<MenuRight> permissionSet = MenuRightService.FindMenuItemsByRoleId(aspUserroles[0].Id).ToList();

                Session["UserMenu"] = permissionSet;
                Session["UserPermissionSet"] = permissionSet.Select(menuRight => menuRight.Menu.PermissionKey).ToList();
            }
        }

        
        #endregion

    }
}