using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this DomainModels.Category source)
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
        public static DomainModels.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new DomainModels.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new DomainModels.Category();
        }

        #endregion
    }
}
