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
                EmployeeId = source.EmployeeId,
                EmployeeName = source.EmpFName + "  " + source.EmpLName,
                EmployeeCodeName = source.EmpFName + "  " + source.EmpLName
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.EmpJobInfo CreateFrom(this EmpJobInfo source)
        {
            return new DomainModels.EmpJobInfo
            {

                EmployeeId = source.EmployeeId,
                DepartmentId = source.DepartmentId,
                DesigGradeId = source.DesigGradeId,
                DesignationId = source.DesignationId,
                JobTypeId = source.JobTypeId,
                SupervisorId = source.SupervisorId,
                WorkPlaceId = source.WorkplaceId,
                JoiningDt = source.JoiningDt,
                Salary = source.Salary,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.EmpDocsInfo CreateFrom(this EmpDocsInfo source)
        {
            return new DomainModels.EmpDocsInfo
            {
                EmployeeId = source.EmployeeId,
                InsuranceCompany = source.InsuranceCompany,
                InsuranceDt = source.InsuranceDt,
                InsuranceNo = source.InsuranceNo,
                IqamaExpDt = source.IqamaExpDt,
                IqamaNo = source.IqamaNo,
                LicenseExpDt = source.LicenseExpDt,
                LicenseNo = source.LicenseNo,
                LicenseTypeId = source.LicenseTypeId,
                PassportCountryId = source.PassportCountryId,
                VisaIssueCountryId = source.VisaIssueCountryId,
                PassportNo = source.PassportNo,
                PassportExpDt = source.PassportExpDt,
                VisaNo = source.VisaNo,
                VisaExpDt = source.VisaExpDt,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.EmpJobProg CreateFrom(this EmpJobProg source)
        {
            return new DomainModels.EmpJobProg
            {
                EmpJobProgId = source.EmpJobProgId,
                EmployeeId = source.EmployeeId,
                WorkplaceId = source.WorkplaceId,
                DesignationId = source.DesignationId,
                DesigStDt = source.DesigStDt,
                DesigEndDt = source.DesigEndDt,
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.EmpAuthOperationsWorkplace CreateFrom(this EmpAuthOperationsWorkplace source)
        {
            return new DomainModels.EmpAuthOperationsWorkplace
            {
                EmpAuthOperationsWorkplaceId = source.EmpAuthLocationId,
                EmployeeId = source.EmployeeId,
                IsDefault = source.IsDefault,
                IsOperationDefault = source.IsOperationDefault,
                OperationsWorkplaceId = source.OperationsWorkplaceId,
            };
        }

        /// <summary>
        ///  Create entity from  web model
        /// </summary>
        public static DomainModels.Employee CreateFrom(this Employee source)
        {
            return new DomainModels.Employee
            {
                EmployeeId = source.EmployeeId,
                CompanyId = source.CompanyId,
                EmpStatusId = source.EmpStatusId,
                Gender = source.Gender,
                DOB = source.DOB,
                EmpCode = source.EmpCode,
                EmpFName = source.EmpFName,
                EmpLName = source.EmpLName,
                EmpMName = source.EmpMName,
                Notes = source.Notes,
                Notes1 = source.Notes1,
                Notes2 = source.Notes2,
                Notes3 = source.Notes3,
                Notes4 = source.Notes4,
                Notes5 = source.Notes5,
                NationalityId = source.NationalityId,
                EmpJobInfo = source.EmpJobInfo.CreateFrom(),
                Addresses = source.Addresses.Select(add => add.CreateFrom()).ToList(),
                PhoneNumbers = source.PhoneNumbers.Select(phone => phone.CreateFrom()).ToList(),
                EmpDocsInfo = source.EmpDocsInfo.CreateFrom(),
                EmpJobProgs = source.EmpJobProgs.Select(empJobProg => empJobProg.CreateFrom()).ToList(),
                EmpAuthOperationsWorkplaces = source.AuthorizedLocations.Select(location => location.CreateFrom()).ToList(),
            };
        }

        /// <summary>
        ///  Create entity from  web model
        /// </summary>
        public static Employee CreateFromEmployeeDetail(this DomainModels.Employee source)
        {
            return new Employee
            {
                EmployeeId = source.EmployeeId,
                CompanyId = source.CompanyId,
                EmpStatusId = source.EmpStatusId,
                Gender = source.Gender,
                DOB = source.DOB,
                EmpCode = source.EmpCode,
                EmpFName = source.EmpFName,
                EmpLName = source.EmpLName,
                EmpMName = source.EmpMName,
                Notes = source.Notes,
                Notes1 = source.Notes1,
                Notes2 = source.Notes2,
                Notes3 = source.Notes3,
                Notes4 = source.Notes4,
                Notes5 = source.Notes5,
                NationalityId = source.NationalityId,

            };
        }
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmployeeListViewContent CreateFromListViewContent(this DomainModels.Employee source)
        {
            return new EmployeeListViewContent
            {
                Id = source.EmployeeId,
                Code = source.EmpCode,
                FirstName = source.EmpFName,
                LastName = source.EmpLName,
                CompanyCodeName = source.Company != null ? source.Company.CompanyCode + " - " + source.Company.CompanyName : null,
                EmpStatus = source.EmpStatus != null ? source.EmpStatus.EmpStatusCode + " - " + source.EmpStatus.EmpStatusName : null,
                Nationality = source.Nationality != null ? source.Nationality.CountryCode + " - " + source.Nationality.CountryName : null,

            };
        }
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmployeeSearchResponse CreateFrom(this ResponseModels.EmployeeSearchResponse source)
        {
            return new EmployeeSearchResponse
            {
                Employees = source.Employees.Select(emp => emp.CreateFromListViewContent()),
                TotalCount = source.TotalCount

            };
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
                EmpStatuses = source.EmpStatuses.Select(x => x.CreateFrom()),
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
                OperationsWorkPlaces = source.OperationsWorkPlaces.Select(x => x.CreateFromDropDown()),
                AddressTypes = source.AddressTypes.Select(x => x.CreateFrom()),
            };
        }
        #endregion
    }
}