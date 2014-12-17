using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Models.IdentityModels.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cares.WebApi.Areas.Api.Controllers
{    
    /// <summary>
    /// Register user controller
    /// </summary>
    [System.Web.Http.Authorize]
    public class RegisterUserController : ApiController
    {
        #region Private
        private IRegisterUserService registerUserService;
        private ApplicationUserManager _userManager;
        /// <summary>
        /// User Manager 
        /// </summary>
        private ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { _userManager = value; }
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterUserController(IRegisterUserService registerUserService)
        {
            if (registerUserService == null)
            {
                throw new ArgumentNullException("registerUserService");
            }
            this.registerUserService = registerUserService;
        }
        #endregion
        #region Public
       
       

        /// <summary>
        /// Register user using web api
        /// </summary>        
        public async Task<string> Post(RegisterViewModel model)
        {
            model.SelectedRole = "Admin";
            if (ModelState.IsValid)
            {
                double userDomainKey = registerUserService.GetMaxUserDomainKey();
                var user = new User
                {
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email, 
                    Email = model.Email, 
                    UserDomainKey = Convert.ToInt64(userDomainKey)+1   //giving the Max+1 domain key
                };
                User addedUser = AddUser(user, model);
                if (addedUser != null)
                {
                    registerUserService.AddLicenseDetail(model, userDomainKey);
                    return await SendEmailToUser(addedUser, model);
                }
                return "Failed to add user.Something bad happended!";
            }
            return "Given Data is corrupted!";
        }

        /// <summary>
        /// Add User 
        /// </summary>
        private User AddUser(User user, RegisterViewModel model)
        {
            var result = UserManager.Create(user, model.ConfirmPassword);
            if (result.Succeeded)
            {
                var addUserToRoleResult =  UserManager.AddToRole(user.Id, model.SelectedRole);
                if (!addUserToRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(string.Format("Failed to add user to role {0}", model.SelectedRole));
                }
                return user;
            }
            return null;
        }

        /// <summary>
        /// Send Email to User for confirmation
        /// </summary>
        private async Task<string> SendEmailToUser(User user, RegisterViewModel model)
        {
            var code = UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string action = url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code });
            await UserManager.SendEmailAsync(model.Email, "Confirm your account", "Please confirm your account by clicking this link : <a href=" + action + ">Confirm account</a> <br>Your Password is:" + model.Password);
            return url.ToString();
        }

        /// <summary>
        /// Confirm User's email address
        /// </summary>
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
               
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return null;
        }
        #endregion
    }
}