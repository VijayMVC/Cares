using System.Linq;
using DomainResponseModel = Cares.Models.ResponseModels;
using  DomainModels=Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Insurance Rate Mapper
    /// </summary>
    public static class InsuranceRateMapper
    {
        #region Insurance Rate Base Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static ApiModel.InsuranceRateBaseResponse CreateFromBaseResponse(this DomainResponseModel.InsuranceRateBaseResponse source)
        {
            return new ApiModel.InsuranceRateBaseResponse
            {
                Operations = source.Operations.Select(operation => operation.CreateFrom()),
                TariffTypes = source.TariffTypes.Select(tariffType => tariffType.CreateFromDropDown()),
            };
        }
        #endregion

        #region Insurance Rate Search Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper 
        /// </summary>
        public static ApiModel.InsuranceRateSearchResponse CreateFromSearchResponse(this DomainResponseModel.InsuranceRateSearchResponse source)
        {
            return new ApiModel.InsuranceRateSearchResponse
            {
                InsuranceRtMains = source.InsuranceRtMains.Select(insuranceRtMain => insuranceRtMain.CreateFrom()),
                TotalCount = source.TotalCount,
            };
        }
        #endregion

        #region insurance Rate

        /// <summary>
        ///  Insurance Rate Main Content Domain to web Model
        /// </summary>
        public static ApiModel.InsuranceRtMainContent CreateFrom(this DomainResponseModel.InsuranceRtMainContent source)
        {
            return new ApiModel.InsuranceRtMainContent
                   {
                       InsuranceRtMainId = source.InsuranceRtMainId,
                       InsuranceRtMainCode = source.InsuranceRtMainCode,
                       InsuranceRtName = source.InsuranceRtName,
                       OperationCodeName = source.OperationCodeName,
                       OperationId = source.OperationId,
                       TariffTypeCodeName = source.TariffTypeCodeName,
                       TariffTypeId = source.TariffTypeId,
                       InsuranceRtMainDescription = source.InsuranceRtMainDescription,
                       StartDt = source.StartDt,
                   };
        }
        /// <summary>
        ///  Insurance Rate Main Web to Domain Model
        /// </summary>
        public static DomainModels.InsuranceRtMain CreateFrom(this ApiModel.InsuranceRtMainContent source)
        {
            return new DomainModels.InsuranceRtMain
            {
                InsuranceRtMainId = source.InsuranceRtMainId,
                InsuranceRtMainCode = source.InsuranceRtMainCode,
                InsuranceRtMainName = source.InsuranceRtName,
                InsuranceRtMainDescription = source.InsuranceRtMainDescription,
                TariffTypeCode = source.TariffTypeId.ToString(),
                StartDt = source.StartDt,
            };
        }
        /// <summary>
        ///  Insurance Rate Detail Content Domain to web Model
        /// </summary>
        public static ApiModel.InsuranceRtDetailContent CreateFrom(this DomainResponseModel.InsuranceRtDetailContent source)
        {
            return new ApiModel.InsuranceRtDetailContent
            {
                InsuranceRtId = source.InsuranceRtId,
                InsuranceRtMainId = source.InsuranceRtMainId,
                InsuranceTypeId = source.InsuranceTypeId,
                InsuranceTypeCodeName = source.InsuranceTypeCodeName,
                HireGroupDetailCodeName = source.HireGroupDetailCodeName,
                HireGroupDetailId = source.HireGroupDetailId,
                VehicleMakeCodeName = source.VehicleMakeCodeName,
                VehicleModelCodeName = source.VehicleModelCodeName,
                VehicleCategoryCodeName = source.VehicleCategoryCodeName,
                ModelYear = source.ModelYear,
                InsuranceRate = source.InsuranceRate,
                StartDate = source.StartDate,
                IsChecked = source.IsChecked,
                RevisionNumber = source.RevisionNumber,
            };
        }
        #endregion
        #region insurance Rate Detail Response Mapper

        /// <summary>
        ///  Insurance Rate Detail Content Domain to web Model
        /// </summary>
        public static ApiModel.InsuranceRtDetailResponse CreateFrom(this DomainResponseModel.InsuranceRtDetailResponse source)
        {
            return new ApiModel.InsuranceRtDetailResponse
            {
                InsuranceRateDetails = source.InsuranceRateDetails.Select(x => x.CreateFrom()),

            };
        }

        #endregion
    }
}