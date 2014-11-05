using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Chauffer Charge Detail API Controller
    /// </summary>
    [Authorize]
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
        public IEnumerable<ChaufferCharge> Get([FromUri] ChaufferChargeMain chaufferChargeMain)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return chaufferChargeService.GetChaufferChargesByChaufferChargeMainId(chaufferChargeMain.ChaufferChargeMainId).Select(chaufferChrg => chaufferChrg.CreateFrom()).ToList();
        }
        #endregion
    }
}