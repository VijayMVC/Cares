using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Discount Sub Type Base Controller
    /// </summary>
    public class DiscountSubTypeBaseController : ApiController
    {
        #region Private
        private readonly IDiscountSubTypeService discountSubTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DiscountSubTypeBaseController(IDiscountSubTypeService discountSubTypeService)
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
        /// Get Discount Sub Type Base Data
        /// </summary>
        public Models.DiscountSubTypeBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return discountSubTypeService.LoadDiscountSubTypeBaseData().CreateFrom();
        }
        #endregion

    }
}