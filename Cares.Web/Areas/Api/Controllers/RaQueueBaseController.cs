using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// RA Queue Base API Controller
    /// </summary>
    public class RaQueueBaseController : ApiController
    {

        #region Private
        private readonly IRaQueueService raQueueService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RaQueueBaseController(IRaQueueService raQueueService)
        {
            if (raQueueService == null)
            {
                throw new ArgumentNullException("raQueueService");
            }

            this.raQueueService = raQueueService;
        }
        #endregion

        #region Public
        // GET api/<controller>
        public RaQueueBaseResponse Get()
        {
            return raQueueService.GetBaseData().CreateFrom();
        }
        #endregion

    }
}