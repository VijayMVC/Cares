using System.Linq;
using ProductResponse = Cares.Web.Models.ProductResponse;

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
        public static ProductResponse CreateFrom(this global::Cares.Models.ResponseModels.ProductResponse source)
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
