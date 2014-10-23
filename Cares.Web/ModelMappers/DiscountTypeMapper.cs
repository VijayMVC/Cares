using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cares.Web.Models;
using SubRegion = Cares.Models.DomainModels.SubRegion;
using SubRegionSearchRequestResponse = Cares.Models.RequestModels.SubRegionSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    public static class DiscountTypeMapper
    {

        /// <summary>
        ///  Create web model[DropDown] from entity
        /// </summary>
        public static DiscountTypeDropDown CreateFrom(this Cares.Models.DomainModels.DiscountType source)
        {
            return new DiscountTypeDropDown
            {
               DiscountTypeId = source.DiscountTypeId,
               DiscountTypeCodeName = source.DiscountTypeCode+" - "+source.DiscountTypeName
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static DiscountTypeSearchRequestResponse CreateFrom(this Cares.Models.RequestModels.DiscountTypeSearchRequestResponse source)
        {
            return new DiscountTypeSearchRequestResponse
            {
                DiscountTypes = source.DiscountTypes.Select(discountType => discountType.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        ///  Create from domain model to web model
        /// </summary>
        public static DiscountType CreateFromm(this Cares.Models.DomainModels.DiscountType source)
        {
            return new DiscountType
            {
                DiscountTypeId = source.DiscountTypeId,
                DiscountTypeCode = source.DiscountTypeCode,
                DiscountTypeName = source.DiscountTypeName,
                DiscountTypeDescrition = source.DiscountTypeDescription
            };
        }


        /// <summary>
        ///  Create from web model 
        /// </summary>
        public static Cares.Models.DomainModels.DiscountType CreateFrom(this DiscountType source)
        {
            return new Cares.Models.DomainModels.DiscountType
            {
                DiscountTypeId = source.DiscountTypeId,
                DiscountTypeCode = source.DiscountTypeCode,
                DiscountTypeName = source.DiscountTypeName,
                DiscountTypeDescription = source.DiscountTypeDescrition
            };
        }
    }
}