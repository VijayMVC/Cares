using Product = Cares.Web.Models.Product;

namespace Cares.Web.ModelMappers
{
    public static class ProductMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Product CreateFrom(this global::Models.DomainModels.Product source)
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
        public static global::Models.DomainModels.Product CreateFrom(this Product source)
        {
             return new global::Models.DomainModels.Product
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
