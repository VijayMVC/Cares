
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

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
        public static Department CreateFrom(this DomainModels.Department source)
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
        public static DomainModels.Department CreateFrom(this Department source)
        {
            if (source != null)
            {
                return new DomainModels.Department
                {
                    DepartmentId = source.DepartmentId,
                    DepartmentName = source.DepartmentName,
                };
            }
            return new DomainModels.Department();
        }

        #endregion
    }
}