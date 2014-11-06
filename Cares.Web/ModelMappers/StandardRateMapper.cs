using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using ApiModels = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class StandardRateMapper
    {
        #region For Tariff Rate
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static StandardRate CreateFrom(this ApiModels.StandardRate source)
        {
            return new StandardRate
            {
                StandardRtId = source.StandardRtId,
                ChildStandardRtId=source.ChildStandardRtId,
                StandardRtMainId = source.StandardRtMainId,
                AllowedMileage = source.AllowMileage,
                ExcessMileageChrg = source.ExcessMileageCharge,
                StandardRt = source.StandardRt,
                StandardRtEndDt = source.EndDt,
                StandardRtStartDt=source.StartDate,
                HireGroupDetailId = source.HireGroupDetailId,
                RevisionNumber = source.RevisionNumber,
                
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static ApiModels.StandardRate CreateFrom(this StandardRate source)
        {
            return new ApiModels.StandardRate
            {
                StandardRtId = source.StandardRtId,
                ChildStandardRtId = source.ChildStandardRtId,
                HireGroupDetailId = source.HireGroupDetailId,
                StandardRtMainId = source.StandardRtMainId,
                AllowMileage = source.AllowedMileage,
                ExcessMileageCharge = source.ExcessMileageChrg,
                StandardRt = source.StandardRt,
                EndDt = source.StandardRtEndDt,
                StartDate = source.StandardRtStartDt,
                RevisionNumber=source.RevisionNumber

            };
        }


        public static StandardRateReportResponse CreateStandardRateReportResponse(this StandardRate source)
        {
            return new StandardRateReportResponse
            {
                TarrifTypeName = source.StandardRtMain.TariffTypeCode,
                HireGroupName = source.HireGroupDetail.HireGroup.HireGroupName,
                VehicleModel = source.HireGroupDetail.VehicleModel.VehicleModelName,
                VehicleMake = source.HireGroupDetail.VehicleMake.VehicleMakeName,
                VehicleCategory = source.HireGroupDetail.VehicleCategory.VehicleCategoryName,
                AllowedMileage = source.AllowedMileage,
                ExcessMileageCharges = source.ExcessMileageChrg,
                ModelYear = source.HireGroupDetail.ModelYear,
                StandradRate = source.StandardRt,
                SREndDate = source.StandardRtEndDt,
                SRStartDate = source.StandardRtStartDt,
                StandradRateType = source.StandardRtMain.StandardRtMainCode,
                RevesionNumber = source.RevisionNumber,
                OperationName = "No name"
            };
        }
        #endregion
    }
}