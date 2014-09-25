using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Chauffer Charge Detail API Controller
    /// </summary>
    public class ChaufferChargeDetailController : ApiController
    {
        #region Private
        private readonly IChaufferChargeService chaufferChargeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeDetailController(IChaufferChargeService chaufferChargeService)
        {
            if (chaufferChargeService == null) throw new ArgumentNullException("chaufferChargeService");
            this.chaufferChargeService = chaufferChargeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public ChaufferChargeSearchResponse Get([FromUri] ChaufferChargeMain chaufferChargeMain)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            //return chaufferChargeService.LoadAll(request).CreateFrom();
            return null;
        }
        #endregion
    }
}