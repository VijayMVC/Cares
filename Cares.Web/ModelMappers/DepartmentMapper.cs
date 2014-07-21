
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Department Mapper
    /// </summary>
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
                DepartmentId = source.DepartmentId,
                DepartmentName = source.DepartmentCode+"-"+source.DepartmentName,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.Department
                {
                    DepartmentId = source.DepartmentId,
                    DepartmentName = source.DepartmentName,
                };
            }
            return new global::Models.DomainModels.Department();
        }

        #endregion
    }
}