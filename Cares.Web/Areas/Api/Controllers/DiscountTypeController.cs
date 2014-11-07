using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using DiscountTypeSearchRequestResponse = Cares.Web.Models.DiscountTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Discount Type Controller
    /// </summary>
    [Authorize]
    public class DiscountTypeController : ApiController
    {
       #region Private
        private readonly IDiscountTypeService discountTypeService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountTypeController(IDiscountTypeService discountTypeService)
        {
            if (discountTypeService == null)
            {
                throw new ArgumentNullException("discountTypeService");
            }
            this.discountTypeService = discountTypeService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Discount Types
        /// </summary>
        public DiscountTypeSearchRequestResponse Get([FromUri] DiscountTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return discountTypeService.SearchDiscountType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Discount Type 
        /// </summary>
        [ApiException]
        public Boolean Delete(DiscountType discountType)
        {
            if (discountType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            discountTypeService.DeleteDiscountType(discountType.DiscountTypeId);
            return true;
        }

        /// <summary>
        ///  ADD / Update Discount Type
        /// </summary>
        [ApiException]
        public DiscountType Post(DiscountType discountType)
        {
            if (discountType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return discountTypeService.SaveDiscountType(discountType.CreateFrom()).CreateDiscountTypeFrom();
        }

        #endregion
    }
}