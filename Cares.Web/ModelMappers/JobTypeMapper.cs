using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

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
    }
}