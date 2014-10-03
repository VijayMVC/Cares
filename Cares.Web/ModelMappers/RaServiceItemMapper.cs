using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaServiceItem Mapper
    /// </summary>
    public static class RaServiceItemMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaServiceItem CreateFrom(this DomainModels.RaServiceItem source)
        {
            return new RaServiceItem
            {
                RaServiceItemId = source.RaServiceItemId,
                RaMainId = source.RaMainId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                TariffType = source.TariffType,
                Quantity = source.Quantity,
                RaServiceItemDescription = source.RaServiceItemDescription,
                ServiceCharge = source.ServiceCharge,
                ServiceItemCode = source.ServiceItem != null ? source.ServiceItem.ServiceItemCode : string.Empty,
                ServiceItemId = source.ServiceItemId,
                ServiceItemName = source.ServiceItem != null ? source.ServiceItem.ServiceItemName : string.Empty,
                ServiceRate = source.ServiceRate,
                ServiceTypeCode = source.ServiceItem != null && source.ServiceItem.ServiceType != null ? source.ServiceItem.ServiceType.ServiceTypeCode : string.Empty,
                ServiceTypeName = source.ServiceItem != null && source.ServiceItem.ServiceType != null ? source.ServiceItem.ServiceType.ServiceTypeName : string.Empty
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaServiceItem CreateFrom(this RaServiceItem source)
        {
            return new DomainModels.RaServiceItem
            {
                RaServiceItemId = source.RaServiceItemId,
                RaMainId = source.RaMainId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                TariffType = source.TariffType,
                Quantity = source.Quantity,
                ServiceCharge = source.ServiceCharge,
                ServiceItemId = source.ServiceItemId,
                ServiceRate = source.ServiceRate
            };

        }

        #endregion

    }
}
