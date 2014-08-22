using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Operation Mapper
    /// </summary>
    public static class OperationMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OperationDropDown CreateFrom(this Operation source)
        {
            return new ApiModel.OperationDropDown
            {
                OperationId = source.OperationId,
                OperationCodeName = source.OperationCode + "-" + source.OperationName,
                DepartmentId = source.Department != null ? source.Department.DepartmentId : 0
            };
        }
        public static Operation CreateFrom(this ApiModel.Operation operation)  // web to server
        {
            return new Operation
            {
                OperationId = operation.OperationId,
                OperationCode = operation.OperationCode,
                OperationName = operation.OperationName,
                OperationDescription = operation.OperationDescription,
                DepartmentId = operation.DepartmentId
            };
        }

        public static ApiModel.OperationBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.OperationBaseDataResponse source)
        {
            return new ApiModel.OperationBaseDataResponse
            {
                Departmens = source.Departments.Select(dept => dept.CreateFrom()),
                Companies = source.Companies.Select(company => company.CreateFrom()),
                DepartmensType = source.Departments.Select(deptType => deptType.DepartmentType)
            };
        }

        public static ApiModel.OperationSearchResponse CreateFrom(this OperationSearchResponse source)
        {
            return new ApiModel.OperationSearchResponse
            {
                Operations = source.Operations.Select(operation => operation.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        public static ApiModel.Operation CreateFromm(this Operation source)
        {
            return new ApiModel.Operation
            {
                OperationId = source.OperationId,
                OperationCode = source.OperationCode,
                OperationName = source.OperationName,
                OperationDescription = source.OperationDescription,
                DepartmentId = source.DepartmentId,
                DepartmentName = source.Department.DepartmentName,
                DepartmentType = source.Department.DepartmentType,
                CompanyName = source.Department.Company.CompanyCode + " - " + source.Department.Company.CompanyName
            };
        } 
        #endregion
        #endregion
    }
}