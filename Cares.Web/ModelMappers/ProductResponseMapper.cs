using System.Linq;
using Cares.Web.Models;
using ResponseModels = Cares.Models.ResponseModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Product Response Mapper
    /// </summary>
    public static class ProductResponseMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ProductResponse CreateFrom(this ResponseModels.ProductResponse source)
        {
            return new ProductResponse
            {
                TotalCount = source.TotalCount,
                Products = source.Products.Select(p => p.CreateFrom())
            };
           
        }

        #endregion

    }
}
