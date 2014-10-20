
using Cares.Web.Models;
using System.Linq;
using DepartmentBaseDataResponse = Cares.Web.Models.DepartmentBaseDataResponse;
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
        /// Create From DomainModel to DropDown
        /// </summary>
        public static DepartmentDropDown CreateFrom(this DomainModels.Department source)
        {
            return new DepartmentDropDown
            {
                DepartmentId = source.DepartmentId,
                DepartmentCodeName = source.DepartmentCode+" - "+source.DepartmentName,
                CompanyId=source.Company !=null ? source.Company.CompanyId:0,
            };
        }

        /// <summary>
        /// Create From response model to web base data 
        /// </summary>
        public static DepartmentBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.DepartmentBaseDataResponse source)
        {
            return new DepartmentBaseDataResponse
            {
                Companies = source.Companies.Select(company => company.CreateFrom())      
            };
        }

        /// <summary>
        /// Create From ResponseModel to web model
        /// </summary>
        public static DepartmentSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.DepartmentSearchRequestResponse source)
        {
            return new DepartmentSearchRequestResponse
            {
                Departments = source.Departments.Select(operation => operation.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
        public static Department CreateFromm(this DomainModels.Department source)
        {
            return new Department
            {
                DepartmentId = source.DepartmentId,
                DepartmentCode = source.DepartmentCode,
                DepartmentName = source.DepartmentName,
                DepartmentDescription = source.DepartmentDescription,
                DepartmentType = source.DepartmentType,
                CompanyId = source.CompanyId,
                CompanyName = source.Company.CompanyName
            };
        }

        /// <summary>
        /// Crete from web model
        /// </summary>
        public static DomainModels.Department CreateFromm(this Department source)
        {
            return new DomainModels.Department
            {
                DepartmentId = source.DepartmentId,
                DepartmentCode = source.DepartmentCode.Trim(),
                DepartmentName = source.DepartmentName,
                DepartmentDescription = source.DepartmentDescription,
                DepartmentType = source.DepartmentType,
                CompanyId = source.CompanyId
            };
        } 
        #endregion
    }
}