using Cares.Commons;
using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Models.MenuModels;
using Cares.Web.ModelMappers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
            Claim domainKeyClaim = ClaimHelper.GetClaimToString(CaresUserClaims.UserDomainKey);
            if (domainKeyClaim!=null)
            {
                return;
            }

         //   Session["LoggedInUser"] = Session["UserDomainKey"] = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                User result = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
             
                Session["LoggedInUser"] = result.UserName;
                Session["UserDomainKey"] = result.UserDomainKey;


                ClaimsIdentity identity = HttpContext.GetOwinContext().Authentication.User.Identities.FirstOrDefault();
                ClaimHelper.AddClaim(new Claim(CaresUserClaims.UserDomainKey, result.UserDomainKey.ToString()), identity);
                ClaimHelper.AddClaim(new Claim(CaresUserClaims.Name, result.UserName), identity);

                IList<UserRole> aspUserroles = result.Roles.ToList();
                // If No role assigned
                if (aspUserroles.Count == 0)
                {
                    return;
                }

                var userRole=    HttpContext.GetOwinContext().Get<ApplicationRoleManager>().FindById(aspUserroles[0].Id).Name;
                ClaimHelper.AddClaim(new Claim(CaresUserClaims.Role, userRole), identity);
                Session["Role"] = userRole;
                IEnumerable<MenuRight> permissionSet = MenuRightService.FindMenuItemsByRoleId(aspUserroles[0].Id).ToList();

              
                IEnumerable<MenuRightClaims> UserMenuClaims = permissionSet.Select(ps => ps.CreateMenuRightClaims());
                ClaimHelper.AddClaim(new Claim(CaresUserClaims.UserMenu, JsonConvert.SerializeObject(UserMenuClaims)), identity);

                IEnumerable<string> PermissionKeyClaims = permissionSet.Select(menuRight => menuRight.CreatePermissionKey());
                ClaimHelper.AddClaim(new Claim(CaresUserClaims.UserPermissionSet, JsonConvert.SerializeObject(PermissionKeyClaims)), identity);
                ClaimHelper.SetCurrentPrincipal(identity);
            //    Session["UserMenu"] = permissionSet;
            //    Session["UserPermissionSet"] = permissionSet.Select(menuRight => menuRight.Menu.PermissionKey).ToList();
            }
        }

        
        #endregion

    }
}