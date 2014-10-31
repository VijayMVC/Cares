using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Chauffer Charge Base API Controller
    /// </summary>
    [Authorize]
    public class ChaufferChargeBaseController : ApiController
    {
        #region Private

        private readonly IChaufferChargeService chaufferChargeService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeBaseController(IChaufferChargeService chaufferChargeService)
        {
            if (chaufferChargeService == null)
            {
                throw new ArgumentNullException("chaufferChargeService");
            }
            this.chaufferChargeService = chaufferChargeService;
        }

        #endregion

        #region Public
        /// <summary>
        /// Get Chauffer Charge Base Data
        /// </summary>
        public Models.ChaufferChargeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return chaufferChargeService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}