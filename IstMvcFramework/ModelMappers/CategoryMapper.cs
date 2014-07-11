using IstMvcFramework.Models;
using MainDomain = Models.DomainModels;

namespace IstMvcFramework.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this MainDomain.Category source)
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
        public static MainDomain.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new MainDomain.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new MainDomain.Category();
        }

        #endregion
    }
}
