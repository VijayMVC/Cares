using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Employee Mapper
    /// </summary>
    public static class EmployeeMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmployeeDropDown CreateFrom(this DomainModels.Employee source)
        {
            return new EmployeeDropDown
            {
                EmployeeId = source.Id,
                EmployeeName = source.Name
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.Employee CreateFrom(this EmployeeDropDown source)
        {
            if (source != null)
            {
                return new DomainModels.Employee
                {
                    Id = source.EmployeeId,
                    Name = source.EmployeeName
                };
            }
            return new DomainModels.Employee();
        }
        #endregion
    }
}