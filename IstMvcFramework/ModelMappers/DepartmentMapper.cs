using IstMvcFramework.Models;
using MainDomain = Models.DomainModels;

namespace IstMvcFramework.ModelMappers
{
    public static class DepartmentMapper
    {
         #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Department CreateFrom(this MainDomain.Department source)
        {
            return new Department
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static MainDomain.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new MainDomain.Department()
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new MainDomain.Department();
        }

        #endregion
    }
}