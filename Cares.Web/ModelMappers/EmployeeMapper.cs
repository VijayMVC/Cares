using Cares.Web.Models;

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
        public static Employee CreateFrom(this Cares.Models.DomainModels.Employee source)
        {
            return new Employee
            {
                Id = source.Id,
                Name = source.Name
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Cares.Models.DomainModels.Employee CreateFrom(this Employee source)
        {
            if (source != null)
            {
                return new Cares.Models.DomainModels.Employee
                {
                    Id = source.Id,
                    Name = source.Name
                };
            }
            return new Cares.Models.DomainModels.Employee();
        }
        #endregion
    }
}