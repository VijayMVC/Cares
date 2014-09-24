using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Additional Charge Mapper
    /// </summary>
    public static class AdditionalChargeMapper
    {
        #region Public
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalChargeSearchResponse CreateFrom(this DomainResponseModel.AdditionalChargeSearchResponse source)
        {
            return new ApiModel.AdditionalChargeSearchResponse
            {
                AdditionalChargeTypes = source.AdditionalChargeTypes.Select(addChrg => addChrg.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalChargeType CreateFrom(this DomainModel.AdditionalChargeType source)
        {
            return new ApiModel.AdditionalChargeType
            {
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                Code = source.AdditionalChargeTypeCode,
                Name = source.AdditionalChargeTypeName,
                Description = source.AdditionalChargeTypeDescription,
                IsEditable = source.IsEditable,
                AdditionalChargeKey = source.AdditionalChargeKey,
            };
        }
        #endregion

        #region  Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalChargeBaseResponse CreateFrom(this DomainResponseModel.AdditionalChargeBaseResponse source)
        {
            return new ApiModel.AdditionalChargeBaseResponse
            {
                HireGroupDetails = source.HireGroupDetails.Select(hg => hg.CreateFromForAddtionalCharge()).ToList(),
            };
        }

        #endregion
    }
}