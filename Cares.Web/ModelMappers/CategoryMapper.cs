using Category = Cares.Web.Models.Category;

namespace Cares.Web.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this global::Models.DomainModels.Category source)
        {
            return new Category
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new global::Models.DomainModels.Category();
        }

        #endregion
    }
}
