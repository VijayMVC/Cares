using DomainModels = Models.DomainModels;
using ResponseModel = Models.ResponseModels;
using ApiModels = Cares.Web.Models;


namespace Cares.Web.ModelMappers
{
    public static class StandardRateMapper
    {
        #region For Tariff Rate
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.StandardRate CreateFrom(this ApiModels.StandardRate source)
        {
            return new DomainModels.StandardRate
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
        public static ApiModels.StandardRate CreateFrom(this DomainModels.StandardRate source)
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
        #endregion
    }
}