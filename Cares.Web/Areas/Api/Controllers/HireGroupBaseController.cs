using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using ApiModels=Cares.Web.Models;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Hire Group base Api Controller
    /// </summary>
    [Authorize]
    public class HireGroupBaseController : ApiController
    { 
        #region Private
        private readonly IHireGroupService hireGroupService;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupBaseController(IHireGroupService hireGroupService)
        {
            if (hireGroupService == null) throw new ArgumentNullException("hireGroupService");
            this.hireGroupService = hireGroupService;
        }

        #endregion
        
        #region Public
        public ApiModels.HireGroupBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return hireGroupService.LoadBaseData().CreateFrom();
        }
        #endregion
       
    }
}