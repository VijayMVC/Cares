using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using MarketingChannelSearchRequestResponse = Cares.Web.Models.MarketingChannelSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// marketing Channel Controller
    /// </summary>
    public class MarketingChannelController : ApiController
    {
       #region Private
        private readonly IMarketingChannelService marketingChannelService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MarketingChannelController(IMarketingChannelService marketingChannelService)
        {
            if (marketingChannelService == null)
            {
                throw new ArgumentNullException("marketingChannelService");
            }
            this.marketingChannelService = marketingChannelService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get  Marketing Channels
        /// </summary>
        public MarketingChannelSearchRequestResponse Get([FromUri] MarketingChannelSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return  marketingChannelService.SearchMarketingChannel(request).CreateFromm();
        }

        /// <summary>
        /// Delete  Marketing Channel 
        /// </summary>
        [ApiException]
        public bool Delete(MarketingChannel marketingChannel)
        {
            if (marketingChannel == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            marketingChannelService.DeleteMarketingChannel(marketingChannel.MarketingChannelId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update  Marketing Channel
        /// </summary>
        [ApiException]
        public MarketingChannel Post(MarketingChannel marketingChannel)
        {
            if (marketingChannel == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return marketingChannelService.AddUpdateMarketingChannel(marketingChannel.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}