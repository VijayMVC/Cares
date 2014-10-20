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
        /// <summary>
        ///  Create dropdown web model from entity
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
        /// <summary>
        /// Create From web model
        /// </summary>
        public static Operation CreateFrom(this ApiModel.Operation operation)  
        {
            return new Operation
            {
                OperationId = operation.OperationId,
                OperationCode = operation.OperationCode.Trim(),
                OperationName = operation.OperationName,
                OperationDescription = operation.OperationDescription,
                DepartmentId = operation.DepartmentId
            };
        }
        /// <summary>
        /// Create From Response Model to web basedata
        /// </summary>
        public static ApiModel.OperationBaseDataResponse CreateFrom(this OperationBaseDataResponse source)
        {
            return new ApiModel.OperationBaseDataResponse
            {
                Departmens = source.Departments.Select(dept => dept.CreateFrom()),
                DepartmensType = source.DepartmentTypes.Select(depttype=>depttype)
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static ApiModel.OperationSearchResponse CreateFrom(this OperationSearchResponse source)
        {
            return new ApiModel.OperationSearchResponse
            {
                Operations = source.Operations.Select(operation => operation.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
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
    }
}