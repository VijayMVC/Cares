using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Models.IdentityModels.ViewModels;
using Cares.Web.Controllers;
using Cares.Web.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Cares.Web.ViewModels.RightsManagement;
using Cares.Models.MenuModels;
using MenuRightModel = Cares.Web.Models.MenuRight;
using Cares.Commons;
using System;

namespace IdentitySample.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {

        private IMenuRightsService menuRightsService;
        public RolesAdminController()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RolesAdminController(IMenuRightsService menuRightsService)
        {
            this.menuRightsService = menuRightsService;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
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

        //
        // GET: /Roles/
        public ActionResult Index()
        {
            return View(RoleManager.Roles.Where(role => !role.Name.ToLower().Equals("admin")));
        }

        //
        // GET: /Roles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<User>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new UserRole{ Name = roleViewModel.Name };
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Edit/Admin
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
            return View(roleModel);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                else
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize (Roles = "Admin")]
        public ActionResult RightsManagement()
        {

            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(string.Empty);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PostRightsManagement(string roleValue, string selectedList)
        {

            UserMenuResponse userMenuRights = menuRightsService.SaveRoleMenuRight(roleValue, selectedList, RoleManager.FindById(roleValue));
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            viewModel.SelectedRoleId = roleValue;
            return View("RightsManagement", viewModel);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RightsManagement(FormCollection collection)
        {
            string RoleId = collection.Get("SelectedRoleId");
            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(RoleId);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new MenuRightModel
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null,

                        }).ToList();
            viewModel.SelectedRoleId = RoleId;
            return View(viewModel);
        }
        /// <summary>
        /// List downs all users for domain key
        /// </summary>
         [Authorize(Roles = "Admin")]
        public ActionResult UsersManagement()
        {
            var domainKeyClaim = ClaimHelper.GetClaimToString(CaresUserClaims.UserDomainKey);
            if (domainKeyClaim == null)
            {
                throw new InvalidOperationException("Domain-Key claim not found!");
            }
            var domainkey= System.Convert.ToInt64(domainKeyClaim.Value);
            var allUsers= UserManager.Users.ToList();
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
         [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            var roles = RoleManager.Roles.ToList();
            ViewBag.UserRoles = roles;
            return View(new UserManagement());
        }

        /// <summary>
        /// Deletes user for User id
        /// </summary>
         [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(string Id)
        {
            var user = UserManager.FindById(Id);
           if (user == null)
                throw new InvalidOperationException("User does not exists!");
            UserManager.Delete(user);
            return RedirectToAction("UsersManagement");
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
            if (status==null)
                return RedirectToAction("UsersManagement");

            var roles = RoleManager.Roles.ToList();
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
            var roles = RoleManager.Roles.ToList();
            var user=UserManager.FindById(id);
            return View(new UserModelForEditUser
            {
                Roles = roles,
                SelectedRole = user.Roles.FirstOrDefault().Id,
                UserEmail = user.Email,
                UserId = user.Id
            });
        }

        /// <summary>
        /// Updates edited user
        /// </summary>
        [HttpPost]
        public ActionResult EditUser(UserModelForEditUser model)
        {
            var selectedRole = RoleManager.Roles.FirstOrDefault(role => role.Id == model.SelectedRole).Name;
            var user = UserManager.FindById(model.UserId);
            UserManager.RemoveFromRole(model.UserId, user.Roles.FirstOrDefault().Name);
            UserManager.AddToRole(model.UserId, selectedRole);
            return RedirectToAction("UsersManagement");
        }
    }
}
