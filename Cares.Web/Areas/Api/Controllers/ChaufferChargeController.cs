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
    /// Chauffer Charge API Controller
    /// </summary>
    [Authorize]
    public class ChaufferChargeController : ApiController
    {
        #region Private
        private readonly IChaufferChargeService chaufferChargeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferChargeController(IChaufferChargeService chaufferChargeService)
        {
            if (chaufferChargeService == null) throw new ArgumentNullException("chaufferChargeService");
            this.chaufferChargeService = chaufferChargeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public ChaufferChargeSearchResponse Get([FromUri] ChaufferChargeSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return chaufferChargeService.LoadAll(request).CreateFrom();

        }


        /// <summary>
        /// Add/Update a Additional Driver Charge
        /// </summary>
        [ApiException]
        public ChaufferChargeMainContent Post(ChaufferChargeMain chaufferChargeMain)
        {
            if (chaufferChargeMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            ChaufferChargeMainContent reponse =
                chaufferChargeService.SaveChaufferCharge(chaufferChargeMain.CreateFrom())
                    .CreateFrom();
            return reponse;

        }

        /// <summary>
        /// Delete a Chauffer Charge
        /// </summary>
        public void Delete(ChaufferChargeMain chaufferChargeMain)
        {
            if (chaufferChargeMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            chaufferChargeService.DeleteAdditionalCharge(chaufferChargeService.FindById(chaufferChargeMain.ChaufferChargeMainId));
        }

        #endregion
    }
}