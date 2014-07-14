using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Controller
    /// </summary>
    public class BusinessPartnerController : ApiController
    {
        #region Private
        /// <summary>
        /// Business Service
        /// </summary>
        private readonly IBusinessPartnerService businessPartnerService;
        #endregion

        #region Public
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerController(IBusinessPartnerService businessPartnerService)
        {
            if (businessPartnerService == null)
            {
                throw new ArgumentNullException("businessPartnerService");    
            }

            this.businessPartnerService = businessPartnerService;
        }
        #endregion

        /// <summary>
        /// Get all Bussiness Partner
        /// </summary>
        public BusinessPartnerResponse Get([FromUri] global::Models.RequestModels.BusinessPartnerSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return businessPartnerService.LoadAllBusinessPartners(request).CreateFrom();
        }

        ///// <summary>
        ///// Update a product
        ///// </summary>
        //public void Post(Cares.Web.Models.Product product)
        //{
        //    if (product == null || !ModelState.IsValid)
        //    {
        //        throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
        //    }

        //    productService.Update(product.CreateFrom());
        //}

        ///// <summary>
        ///// Adds a product
        ///// </summary>
        //public void Put(Cares.Web.Models.Product product)
        //{
        //    if (product == null || !ModelState.IsValid)
        //    {
        //        throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
        //    }

        //    productService.AddProduct(product.CreateFrom());
        //}

        ///// <summary>
        ///// Delete a Product
        ///// </summary>
        //public void Delete(Cares.Web.Models.Product product)
        //{
        //    if (product == null || !ModelState.IsValid)
        //    {
        //        throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
        //    }

        //    productService.DeleteProduct(product.CreateFrom());
        //}
    }
}