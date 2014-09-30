using Cares.Web.Models;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Service Item Mapper Model
    /// </summary>
    public static class ServiceItemMapper
    {
        /// <summary>
        ///  Create from entity model
        /// </summary>
        public static ServiceItem CreateFrom(this Cares.Models.DomainModels.ServiceItem source)
        {
            return new ServiceItem
            {
                ServiceItemId = source.ServiceItemId,
                ServiceItemCode = source.ServiceItemCode,
                ServiceItemName = source.ServiceItemName,
                ServiceItemDescription = source.ServiceItemDescription,
                ServiceTypeId = source.ServiceTypeId,
                ServiceTypeCodeName = source.ServiceType.ServiceTypeCode + "-" + source.ServiceType.ServiceTypeName,
                ServiceTypeName = source.ServiceType.ServiceTypeName
            };
        }

        /// <summary>
        /// Crete From response model to web base data
        /// </summary>
        public static ServiceItemBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.ServiceItemBaseDataResponse source)
        {
            return new ServiceItemBaseDataResponse
            {
                ServiceTypes = source.ServiceTypes.Select(serviceType => serviceType.CreateFromm())
            };
        }

        /// <summary>
        /// Crete From web model
        /// </summary>
        public static Cares.Models.DomainModels.ServiceItem CreateFrom(this ServiceItem source)
        {
            return new Cares.Models.DomainModels.ServiceItem
            {
                ServiceItemId = source.ServiceItemId,
                ServiceItemCode = source.ServiceItemCode,
                ServiceItemName = source.ServiceItemName,
                ServiceItemDescription = source.ServiceItemDescription,
                ServiceTypeId = source.ServiceTypeId
            };
        }

        /// <summary>
        ///  Create from search-request-response domain model
        /// </summary>
        public static ServiceItemSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.ServiceItemSearchRequestResponse source)
        {
            return new ServiceItemSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                ServiceItems = source.ServiceItems.Select(serviceItem => serviceItem.CreateFrom())
            };
        }


    }
}