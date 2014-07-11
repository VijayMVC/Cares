using System;
using System.Globalization;
using MainDomain = Models.DomainModels;

namespace IstMvcFramework.ModelMappers
{
    public static class EmployeeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.Employee CreateFrom(this MainDomain.Employee source)
        {
            return new Models.Employee
            {
                Id = source.Id,
                Name = source.Name,
                DepartmentId = source.DepartmentId,
                Bio = source.Bio,
                DateOfBirth = Convert.ToDateTime(source.DateOfBirth).ToShortDateString(),
                Department = source.Department.CreateFrom(),
                ImageName = source.Image
            };

        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static MainDomain.Employee CreateFrom(this Models.Employee source)
        {
            return new MainDomain.Employee
            {
                Id = source.Id,
                Name = source.Name,
                DepartmentId = source.DepartmentId,
                Bio = source.Bio,
                DateOfBirth = DateTime.ParseExact(source.DateOfBirth, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                Image = source.ImageName
            };

        }

        #endregion
    }
}