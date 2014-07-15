using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Base Controller
    /// </summary>
    public class BusinessPartnerBaseController : ApiController
    {
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerBaseController(ICategoryService categoryService)
        {
            if (categoryService == null)
            {
                throw new ArgumentNullException("categoryService");
            }
   
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Get Base Data
        /// </summary>
        public IEnumerable<Category> Get()
        {
            return categoryService.LoadAllCategories().Select(c => c.CreateFrom());
        }
    }
}