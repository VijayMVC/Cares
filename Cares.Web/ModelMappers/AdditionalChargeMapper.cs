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
            };
        }
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.AdditionalCharge CreateFrom(this DomainModel.AdditionalCharge source)
        {
            return new ApiModel.AdditionalCharge
            {
                AdditionalChargeId = source.AdditionalChargeId,
                HireGroupDetailId = source.HireGroupDetailId,
                StartDt = source.StartDt,
                AdditionalChargeRate = source.AdditionalChargeRate,
                AdditionalChargeTypeCode = source.AdditionalChargeType.AdditionalChargeTypeCode,
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                AdditionalChargeTypeName = source.AdditionalChargeType.AdditionalChargeTypeName,
                AdditionalChargeTypeCodeName = source.AdditionalChargeType.AdditionalChargeTypeCode + '-' + source.AdditionalChargeType.AdditionalChargeTypeName,
                HireGroupDetailCodeName = source.HireGroupDetail != null ? source.HireGroupDetail.CreateFromForAddtionalCharge().HireGroupDetailCodeName : string.Empty,
                RevisionNumber =source.RevisionNumber
            };
        }
        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.AdditionalCharge CreateFrom(this ApiModel.AdditionalCharge source)
        {
            return new DomainModel.AdditionalCharge
            {
                AdditionalChargeId = source.AdditionalChargeId,
                HireGroupDetailId = source.HireGroupDetailId,
                StartDt = source.StartDt,
                AdditionalChargeRate = source.AdditionalChargeRate,
            };
        }

        /// <summary>
        ///  Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.AdditionalChargeType CreateFrom(this ApiModel.AdditionalChargeType source)
        {
            return new DomainModel.AdditionalChargeType
            {
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                AdditionalChargeTypeCode = source.Code,
                AdditionalChargeTypeName = source.Name,
                AdditionalChargeTypeDescription = source.Description,
                IsEditable = source.IsEditable,
                AdditionalCharges = source.AdditionalCharges!=null?source.AdditionalCharges.Select(addChrg => addChrg.CreateFrom()).ToList():null
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