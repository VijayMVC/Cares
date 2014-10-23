using Cares.Web.Models;
using System.Linq;
using DomainModels = Cares.Models.DomainModels;
using JobTypeSearchRequestResponse = Cares.Models.RequestModels.JobTypeSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Job Type Mapper
    /// </summary>
    public static class JobTypeMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static JobTypeDropDown CreateFrom(this DomainModels.JobType source)
        {
            return new JobTypeDropDown
            {
                JobTypeId = source.JobTypeId,
                JobTypeCodeName = source.JobTypeCode + " - " + source.JobTypeName
            };
        }

        /// <summary>
        /// Crete From Response domain model
        /// </summary>
        public static Models.JobTypeSearchRequestResponse CreateFrom(this JobTypeSearchRequestResponse source)
        {
            return new Models.JobTypeSearchRequestResponse
            {
                JobTypes = source.JobTypes.Select(jobType => jobType.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Crete From web model
        /// </summary>
        public static DomainModels.JobType CreateFrom(this JobType source)
        {

            return new DomainModels.JobType
            {
                JobTypeId = source.JobTypeId,
                JobTypeName = source.JobTypeName,
                JobTypeCode = source.JobTypeCode.Trim(),
                JobTypeDescription = source.JobTypeDescription
            };
        }
        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static JobType CreateFromm(this DomainModels.JobType source)
        {
            return new JobType
            {
                JobTypeId=source.JobTypeId,
                JobTypeName = source.JobTypeName,
                JobTypeCode = source.JobTypeCode,
                JobTypeDescription = source.JobTypeDescription
            };
        }
    }
}