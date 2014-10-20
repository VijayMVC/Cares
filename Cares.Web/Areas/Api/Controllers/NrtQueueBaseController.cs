using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// NRT Queue Base Controller
    /// </summary>
    public class NrtQueueBaseController : ApiController
    {
        #region Private
        private readonly INrtQueueService nrtQueueService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtQueueBaseController(INrtQueueService nrtQueueService)
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
        public Models.NrtQueueBaseResponse Get()
        {
            return nrtQueueService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}