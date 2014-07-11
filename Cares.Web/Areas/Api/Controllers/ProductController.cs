using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductController(IProductService productService)
        {
            if (productService == null)
            {
                throw new ArgumentNullException("productService");    
            }
   
            this.productService = productService;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        public ProductResponse Get([FromUri] global::Models.RequestModels.ProductSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return productService.LoadAllProducts(request).CreateFrom();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        public void Post(Cares.Web.Models.Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            productService.Update(product.CreateFrom());
        }

        /// <summary>
        /// Adds a product
        /// </summary>
        public void Put(Cares.Web.Models.Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            productService.AddProduct(product.CreateFrom());
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        public void Delete(Cares.Web.Models.Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            productService.DeleteProduct(product.CreateFrom());
        }
    }
}