using Product = Cares.Web.Models.Product;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class ProductMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Product CreateFrom(this DomainModels.Product source)
        {
             return new Product
            {
                Id = source.Id,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Description = source.Description,
                Price = source.Price,
                Category=source.Category.CreateFrom()
            };
           
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.Product CreateFrom(this Product source)
        {
             return new DomainModels.Product
            {
                Id = source.Id,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Description = source.Description,
                Price = source.Price
            };
           
        }

        #endregion

    }
}
