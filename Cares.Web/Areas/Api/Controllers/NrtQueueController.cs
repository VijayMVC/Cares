using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// NRT Queue API Controller
    /// </summary>
    [Authorize]
    public class NrtQueueController : ApiController
    {
        #region Private
        private readonly INrtQueueService nrtQueueService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtQueueController(INrtQueueService nrtQueueService)
        {
            if (nrtQueueService == null)
            {
                throw new ArgumentNullException("nrtQueueService");
            }

            this.nrtQueueService = nrtQueueService;
        }
        #endregion

        #region Public
        // GET api/<controller>
        public Models.NrtQueueSearchResponse Get([FromUri] NrtQueueSearchRequest request)
        {
            return nrtQueueService.LoadNrtQueues((request)).CreateFrom();
        }

        #endregion
    }
}