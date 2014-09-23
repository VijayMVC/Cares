using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using DiscountSubTypeSearchRequestResponse = Cares.Web.Models.DiscountSubTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Discount Sub Type Controller
    /// </summary>
    public class DiscountSubTypeController : ApiController
    {
       #region Private
        private readonly IDiscountSubTypeService discountSubTypeService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountSubTypeController(IDiscountSubTypeService discountSubTypeService)
        {
            if (discountSubTypeService == null)
            {
                throw new ArgumentNullException("discountSubTypeService");
            }
            this.discountSubTypeService = discountSubTypeService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get  Discount  Sub Types
        /// </summary>
        public DiscountSubTypeSearchRequestResponse Get([FromUri] DiscountSubTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
           return discountSubTypeService.SearchDiscountSubType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Discount Sub Type 
        /// </summary>
        [ApiException]
        public Boolean Delete(DiscountSubType discountSubType)
        {
            if (discountSubType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            discountSubTypeService.DeleteDiscountSubType(discountSubType.DiscountSubTypeId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Discount Sub Type
        /// </summary>
        [ApiException]
        public DiscountSubType Post(DiscountSubType discountSubType)
        {
            if (discountSubType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return discountSubTypeService.SaveDiscountSubType(discountSubType.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}