using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Phone Mapper
    /// </summary>
    public static class PhoneMapper
    {
        #region Public
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static Phone CreateFrom(this ApiModel.Phone source)
        {
            return new Phone
            {
                PhoneId = source.PhoneId != null ? (long)source.PhoneId : 0,
                IsDefault = source.IsDefault,
                PhoneNumber = source.PhoneNumber,
                PhoneTypeId = source.PhoneTypeId,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }

        /// <summary>
        ///  Create Web Api model from domain model
        /// </summary>
        public static ApiModel.Phone CreateFrom(this Phone source)
        {
            return new ApiModel.Phone
            {
                PhoneId = source.PhoneId,
                IsDefault = source.IsDefault,
                PhoneNumber = source.PhoneNumber,
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeKey = source.PhoneType != null ? source.PhoneType.PhoneTypeKey : null,
                PhoneTypeName = source.PhoneType != null ? (source.PhoneType.PhoneTypeCode + '-' + source.PhoneType.PhoneTypeName) : string.Empty,
                BusinessPartnerId = source.BusinessPartnerId,
             //   WorkLocationId = source.WorkLocationId
            };
        }

        /// <summary>
        ///  Create Web Api model for worklocation associated phones from domain model []
        /// </summary>
        public static ApiModel.PhonesSearchByWorkLocationIdResponse CreateFrom(this PhonesSearchByWorkLocationIdResponse source)
        {
            return new ApiModel.PhonesSearchByWorkLocationIdResponse
            {
                PhonesAssociatedWithWorkLocation = source.PhonesAssociatedWithWorkLocation.Select(phone => phone.CreateFrom())
            };
        }


        #endregion
    }
}