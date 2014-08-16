
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
        public static DepartmentDropDown CreateFrom(this DomainModels.Department source)
        {
            return new DepartmentDropDown
            {
                DepartmentId = source.DepartmentId,
                DepartmentCodeName = source.DepartmentCode+" - "+source.DepartmentName,
                CompanyId=source.Company!=null?source.Company.CompanyId:0,
            };
        }

        #endregion
    }
}