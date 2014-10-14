using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// RA Queue API Controller
    /// </summary>
    public class RaQueueController : ApiController
    {
        #region Private
        private readonly IRaQueueService raQueueService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RaQueueController(IRaQueueService raQueueService)
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
        public Models.RaMainForRaQueueSearchResponse Get([FromUri] RaQueueSearchRequest request)
        {
            return raQueueService.LoadRaQueues((request)).CreateFrom();
        }

        #endregion
    }
}