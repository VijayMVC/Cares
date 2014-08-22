using System;
using System.Linq;
using DomainResponseModel = Cares.Models.ResponseModels;
using DomainModels = Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Service Rate Mapper
    /// </summary>
    public static class ServiceRtMapper
    {
        #region Service Rate Base Response Mapper
        /// <summary>
        ///  Service Type Base Response Mapper
        /// </summary>
        public static ApiModel.ServiceRateBaseResponse CreateFrom(this DomainResponseModel.ServiceRateBaseResponse source)
        {
            return new ApiModel.ServiceRateBaseResponse
            {
                Operations = source.Operations.Select(operation => operation.CreateFrom()),
                TariffTypes = source.TariffTypes.Select(tariffType => tariffType.CreateFromDropDown()),
            };
        }
        #endregion

        #region Service Rate Search Response Mapper
        /// <summary>
        ///  Service Rate Base Response Mapper 
        /// </summary>
        public static ApiModel.ServiceRateSearchResponse CreateFrom(this DomainResponseModel.ServiceRateSearchResponse source)
        {
            return new ApiModel.ServiceRateSearchResponse
            {
                ServiceRtMains = source.ServiceRtMains.Select(insuranceRtMain => insuranceRtMain.CreateFrom()),
                TotalCount = source.TotalCount,
            };
        }
        #endregion

        #region insurance Rate

        /// <summary>
        ///  Service Rate Main Content Domain to web Model
        /// </summary>
        public static ApiModel.ServiceRtMainContent CreateFrom(this DomainResponseModel.ServiceRtMainContent source)
        {
            return new ApiModel.ServiceRtMainContent
            {
                ServiceRtMainId = source.ServiceRtMainId,
                ServiceRtMainCode = source.ServiceRtMainCode,
                ServiceRtMainName = source.ServiceRtMainName,
                OperationCodeName = source.OperationCodeName,
                OperationId = source.OperationId,
                TariffTypeCodeName = source.TariffTypeCodeName,
                TariffTypeId = source.TariffTypeId,
                ServiceRtMainDescription = source.ServiceRtMainDescription,
                StartDt = source.StartDt,
            };
        }
        ///// <summary>
        /////  Service Rate Main Web to Domain Model
        ///// </summary>
        //public static DomainModels.ServiceRtMain CreateFrom(this ApiModel.ServiceRtMainContent source)
        //{
        //    return new DomainModels.InsuranceRtMain
        //    {
        //        InsuranceRtMainId = source.InsuranceRtMainId,
        //        InsuranceRtMainCode = source.InsuranceRtMainCode,
        //        InsuranceRtMainName = source.InsuranceRtName,
        //        InsuranceRtMainDescription = source.InsuranceRtMainDescription,
        //        TariffTypeCode = source.TariffTypeId.ToString(),
        //        StartDt = source.StartDt,
        //        InsuranceRates = source.InsuranceRts != null ? source.InsuranceRts.Select(insuranceRt => insuranceRt.CreateFrom()).ToList() : null
        //    };
        //}
        /// <summary>
        ///  Service Rate Detail Content Domain to web Model
        /// </summary>
        public static ApiModel.ServiceRtDetailContent CreateFrom(this DomainResponseModel.ServiceRtDetailContent source)
        {
            return new ApiModel.ServiceRtDetailContent
            {
                ServiceRtId = source.ServiceRtId,
                ServiceRtMainId = source.ServiceRtMainId,
                ServiceItemId = source.ServiceItemId,
                ServiceItemCode = source.ServiceItemCode,
                ServiceItemName = source.ServiceItemName,
                ServiceRate = source.ServiceRate,
                StartDt = source.StartDt,
                ServiceTypeCodeName = source.ServiceTypeCodeName,
                IsChecked = source.IsChecked,
                RevisionNumber = source.RevisionNumber,
            };
        }
        ///// <summary>
        /////  Web To entity
        ///// </summary>
        //public static DomainModels.ServiceRt CreateFrom(this ApiModel.InsuranceRtDetailContent source)
        //{
        //    return new DomainModels.InsuranceRt
        //    {
        //        InsuranceRtId = source.InsuranceRtId,
        //        InsuranceRtMainId = source.InsuranceRtMainId,
        //        InsuranceTypeId = source.InsuranceTypeId,
        //        HireGroupDetailId = source.HireGroupDetailId,
        //        InsuranceRate = source.InsuranceRate,
        //        StartDt = source.StartDate,
        //        RevisionNumber = source.RevisionNumber,
        //    };
        //}
        //#endregion
        //#region insurance Rate Detail Response Mapper

        /// <summary>
        ///  Service Rate Detail Content Domain to web Model
        /// </summary>
        public static ApiModel.ServiceRtDetailResponse CreateFrom(this DomainResponseModel.ServiceRtDetailResponse source)
        {
            return new ApiModel.ServiceRtDetailResponse
            {
                ServiceRateDetails = source.ServiceRateDetails.Select(x => x.CreateFrom())

            };
        }

        //#endregion
        #endregion
    }
}