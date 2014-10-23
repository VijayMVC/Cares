using System.Linq;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
using SubRegionSearchRequestResponse = Cares.Models.RequestModels.SubRegionSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Employee Status Mapper
    /// </summary>
    public static class EmpStatusMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static EmpStatusDropDown CreateFrom(this DomainModels.EmpStatus source)
        {
            return new EmpStatusDropDown
            {
                EmpStatusId = source.EmpStatusId,
                EmpStatusCodeName = source.EmpStatusCode + " - " + source.EmpStatusName
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static EmpSearchRequestResponse CreateFrom(this  Cares.Models.RequestModels.EmpSearchRequestResponse source)
        {
            return new EmpSearchRequestResponse
            {
                EmployeeStatuses = source.EmployeeStatuses.Select(region => region.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static EmpStatus CreateFromm(this DomainModels.EmpStatus source)
        {
            return new EmpStatus
            {
               EmpStatusId = source.EmpStatusId,
               EmpStatusCode = source.EmpStatusCode,
               EmpStatusName = source.EmpStatusName,
               EmpStatusDescription = source.EmpStatusDescription,
               EmpStatusFlag = source.EmpStatusFlag
            };
        }


        /// <summary>
        ///  Create from web model 
        /// </summary>
        public static DomainModels.EmpStatus CreateFrom(this EmpStatus source)
        {
            return new DomainModels.EmpStatus
            {
                EmpStatusId = source.EmpStatusId,
                EmpStatusCode = source.EmpStatusCode.Trim(),
                EmpStatusName = source.EmpStatusName,
                EmpStatusDescription = source.EmpStatusDescription,
                EmpStatusFlag = source.EmpStatusFlag
            };
        }
    }
}