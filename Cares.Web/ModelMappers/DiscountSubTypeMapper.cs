using Cares.Web.Models;
using System.Linq;
using DiscountSubTypeSearchRequestResponse = Cares.Web.Models.DiscountSubTypeSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Discount Sub Type Mapper Model
    /// </summary>
    public static class DiscountSubTypeMapper
    {
        /// <summary>
        /// Crete From response model to web base data [DropDown]
        /// </summary>
        public static DiscountSubTypeBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.DiscountSubTypeBaseDataResponse source)
        {
            return new DiscountSubTypeBaseDataResponse
            {
                DiscountTypeDropDown = source.DiscountTypes.Select(discountType => discountType.CreateFrom())
            };
        }

        /// <summary>
        /// Crete From Web model
        /// </summary>
        public static Cares.Models.DomainModels.DiscountSubType CreateFrom(this DiscountSubType source)
        {
            return new Cares.Models.DomainModels.DiscountSubType
            {
                DiscountTypeId = source.DiscountTypeId,
                DiscountSubTypeName = source.DiscountSubTypeName,
                DiscountSubTypeCode = source.DiscountSubTypeCode,
                DiscountSubTypeId = source.DiscountSubTypeId,
                DiscountSubTypeDescription = source.DiscountSubTypeDescription
            };
        }


        /// <summary>
        /// Crete From Discount Sub Type Search Response Domain Model
        /// </summary>
        public static DiscountSubTypeSearchRequestResponse CreateFrom(this Cares.Models.RequestModels.DiscountSubTypeSearchRequestResponse source)
        {
            return new DiscountSubTypeSearchRequestResponse
            {
                DiscountSubTypes = source.DiscountSubTypes.Select(discountSubType => discountSubType.CreateDiscountSubTypeFrom()),
                TotalCount = source.TotalCount
            };
        }


        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static DiscountSubType CreateDiscountSubTypeFrom(this Cares.Models.DomainModels.DiscountSubType source)
        {
            return new DiscountSubType
            {
                DiscountTypeId = source.DiscountTypeId,
                DiscountTypeName = source.DiscountType.DiscountTypeName,
                DiscountSubTypeName = source.DiscountSubTypeName,
                DiscountSubTypeCode = source.DiscountSubTypeCode,
                DiscountSubTypeId = source.DiscountSubTypeId,
                DiscountSubTypeDescription = source.DiscountSubTypeDescription
            };
        }
    }
}