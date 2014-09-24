
using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Service Type Mapper
    /// </summary>
    public static class ServiceTypeMapper
    {
        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.ServiceTypeSearchRequestResponse CreateFrom(this ServiceTypeSearchRequestResponse source)
        {
            return new Models.ServiceTypeSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                ServiceTypes = source.ServiceTypes.Select(serviceType => serviceType.CreateFrom())
            };
        }

        /// <summary>
        ///  Create web model from Domain model
        /// </summary>
        public static Models.ServiceType CreateFrom(this ServiceType source)
        {
            return new Models.ServiceType
            {
                ServiceTypeId = source.ServiceTypeId,
                ServiceTypeCode = source.ServiceTypeCode,
                ServiceTypeName = source.ServiceTypeName,
                ServiceTypeDescription = source.ServiceTypeDescription
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static ServiceType CreateFrom(this Models.ServiceType source)
        {
            return new ServiceType
            {
                ServiceTypeId = source.ServiceTypeId,
                ServiceTypeCode = source.ServiceTypeCode,
                ServiceTypeName = source.ServiceTypeName,
                ServiceTypeDescription = source.ServiceTypeDescription
            };
        }
    }
}