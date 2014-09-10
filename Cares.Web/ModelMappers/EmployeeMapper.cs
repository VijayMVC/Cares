using System.Linq;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
using ResponseModels = Cares.Models.ResponseModels;
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

        #region Base Data Response
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmployeeBaseResponse CreateFrom(this ResponseModels.EmployeeBaseResponse source)
        {
            return new EmployeeBaseResponse
            {
               EmpStatuses = source.EmpStatuses.Select(x=>x.CreateFrom()),
               Companies = source.Companies.Select(x => x.CreateFrom()),
               JobTypes = source.JobTypes.Select(x => x.CreateFrom()),
               Designations = source.Designations.Select(x => x.CreateFrom()),
               DesigGrades = source.DesigGrades.Select(x => x.CreateFrom()),
               Departments = source.Departments.Select(x => x.CreateFrom()),
               WorkPlaces = source.WorkPlaces.Select(x => x.CreateFromm()),
               Supervisors = source.Supervisors.Select(x => x.CreateFrom()),
               Countries = source.Countries.Select(x => x.CreateFrom()),
               Regions = source.Regions.Select(x => x.CreateFrom()),
               SubRegions = source.SubRegions.Select(x => x.CreateFrom()),
               Cities = source.Cities.Select(x => x.CreateFrom()),
               Areas = source.Areas.Select(x => x.CreateFrom()),
               PhoneTypes = source.PhoneTypes.Select(x => x.CreateFrom()),
               LicenseTypes = source.LicenseTypes.Select(x => x.CreateFrom()),
               Operations = source.Operations.Select(x => x.CreateFrom()),
               OperationsWorkPlaces = source.OperationsWorkPlaces.Select(x => x.CreateFrom()),


            };
        }
        #endregion
    }
}