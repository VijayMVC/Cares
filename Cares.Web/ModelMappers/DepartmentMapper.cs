using Department = Cares.Web.Models.Department;

namespace Cares.Web.ModelMappers
{
    public static class DepartmentMapper
    {
         #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Department CreateFrom(this global::Models.DomainModels.Department source)
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
        public static global::Models.DomainModels.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.Department()
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new global::Models.DomainModels.Department();
        }

        #endregion
    }
}