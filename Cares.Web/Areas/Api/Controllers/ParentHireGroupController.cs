using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Parent Hiregroup Controller
    /// </summary>
    [Authorize]
    public sealed class ParentHireGroupController : ApiController
    {
        private readonly IHireGroupService hireGroupService;

        #region Private
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ParentHireGroupController(IHireGroupService hireGroupService)
        {
            this.hireGroupService = hireGroupService;
        }

        #endregion
        #region Public
        /// <summary>
        /// Get Parent Hiregroup
        /// </summary>
        public ParentHireGroupResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return new ParentHireGroupResponse
            {
                HireGroups = hireGroupService.GetParentHireGroups().Select(hg => hg.CreateFromParentHireGroup())
            };
        }
        #endregion
    }
}