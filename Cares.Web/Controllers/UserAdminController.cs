using Cares.Implementation.Identity;
using Cares.Models.IdentityModels;
using Cares.Models.IdentityModels.ViewModels;
using Cares.WebBase.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cares.Models.DomainModels;
using Cares.Web.Models;
using Cares.Commons;

namespace Cares.Web.Controllers
{

    /// <summary>
    /// User Management Controller 
    /// </summary>
    [SiteAuthorize( PermissionKey = "**ThisMakesNoSenseIKnow**")]
    public class UsersAdminController : Controller
    {
        public UsersAdminController()
        {
        }
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
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        /// <summary>
        /// List downs all users for domain key
        /// </summary>
        public ActionResult Index()
        {
            var domainKeyClaim = ClaimHelper.GetClaimToString(CaresUserClaims.UserDomainKey);
            if (domainKeyClaim == null)
            {
                throw new InvalidOperationException("Domain-Key claim not found!");
            }
            var domainkey = System.Convert.ToInt64(domainKeyClaim.Value);
            var allUsers = UserManager.Users.ToList();
            var model = allUsers.Where(user => user.UserDomainKey == domainkey).Select(user => new UserManagement
            {
                DomainKey = user.UserDomainKey,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserEmail = user.Email,
                UserRole = user.Roles.FirstOrDefault().Name
            });
            return View(model);
        }

        /// <summary>
        /// Creates new user model 
        /// </summary>
        public ActionResult CreateUser()
        {
            var roles = RoleManager.Roles.Where(role => role.Name != "SystemAdministrator").ToList();
            ViewBag.UserRoles = roles;
            return View(new UserManagement());
        }

        /// <summary>
        /// Deletes user for User id
        /// </summary>
        public ActionResult DeleteUser(string Id)
        {
            var user = UserManager.FindById(Id);
            if (user == null)
                throw new InvalidOperationException("User does not exists!");
            UserManager.Delete(user);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Adds new user 
        /// </summary>
        [HttpPost]
        public ActionResult CreateUser(UserManagement model)
        {
            if (model == null)
                throw new InvalidOperationException("User Does not exists!");
            var domainKeyClaim = ClaimHelper.GetClaimToString(CaresUserClaims.UserDomainKey);
            if (domainKeyClaim == null)
            {
                throw new InvalidOperationException("Domain-Key claim not found!");
            }
            var domainkey = System.Convert.ToInt64(domainKeyClaim.Value);
            var user = new User
            {
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserEmail,
                Email = model.UserEmail,
                UserDomainKey = domainkey
            };
            var status = AddUserToUserManager(user, model);
            if (status == null)
                return RedirectToAction("Index");

            var roles = RoleManager.Roles.Where(role => role.Name != "SystemAdministrator").ToList(); ;
            ViewBag.UserRoles = roles;
            ViewBag.UserError = status;
            return View(new UserManagement());
        }

        /// <summary>
        /// Add User 
        /// </summary>
        private string AddUserToUserManager(User user, UserManagement model)
        {
            var result = UserManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                var addUserToRoleResult = UserManager.AddToRole(user.Id, model.UserRole);
                if (!addUserToRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Format("Failed to add user to role {0}",
                        model.UserRole));
                }
            }
            return result.Errors.FirstOrDefault();
        }

        /// <summary>
        /// Edits user for user id 
        /// </summary>
        public ActionResult EditUser(string id)
        {
            var roles = RoleManager.Roles.Where(role => role.Name != "SystemAdministrator").ToList();
            var user = UserManager.FindById(id);
            return View(new UserModelForEditUser
            {
                Roles = roles,
                SelectedRole = user.Roles.FirstOrDefault().Id,
                UserEmail = user.Email,
                id = user.Id
            });
        }

        /// <summary>
        /// Updates edited user
        /// </summary>
        [HttpPost]
        public ActionResult EditUser(UserModelForEditUser model)
        {
            var selectedRole = RoleManager.Roles.FirstOrDefault(role => role.Id == model.SelectedRole).Name;
            var user = UserManager.FindById(model.id);
            UserManager.RemoveFromRole(model.id, user.Roles.FirstOrDefault().Name);
            UserManager.AddToRole(model.id, selectedRole);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// View user details
        /// </summary>
        public ActionResult ViewUserDetail(string id)
        {
            var user = UserManager.FindById(id);
            if (user == null)
                throw new InvalidOperationException("User Not found!");
            var userModel = new UserModelForEditUser
            {
                id = user.Id,
                UserEmail = user.Email,
                PhoneNumber = user.PhoneNumber,
                SelectedRole = user.Roles.FirstOrDefault().Name
            };
            return View(userModel);
        }
    }
}
