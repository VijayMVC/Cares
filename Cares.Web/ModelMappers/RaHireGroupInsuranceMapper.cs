using System;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaHireGroup Insurance Mapper
    /// </summary>
    public static class RaHireGroupInsuranceMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaHireGroupInsurance CreateFrom(this DomainModels.RaHireGroupInsurance source)
        {
            return new RaHireGroupInsurance
            {
                RaHireGroupInsuranceId = source.RaHireGroupInsuranceId,
                RaHireGroupId = source.RaHireGroupId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                InsuranceCharge = source.InsuranceCharge,
                InsuranceRate = source.InsuranceRate,
                InsuranceTypeCodeName = source.InsuranceType != null ? source.InsuranceType.InsuranceTypeCode + '-' + source.InsuranceType.InsuranceTypeName : string.Empty,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                InsuranceTypeId = source.InsuranceTypeId,
                TariffType = source.TariffType,
                //Below Properties are for Reporting in order to format the dates 
                StartDtTimeForReport = source.StartDtTime.ToString("dd-MMM-yy HH:mm"),
                EndDtTimeForReport = source.EndDtTime.ToString("dd-MMM-yy HH:mm")
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaHireGroupInsurance CreateFrom(this RaHireGroupInsurance source)
        {
            return new DomainModels.RaHireGroupInsurance
            {
                RaHireGroupInsuranceId = source.RaHireGroupInsuranceId,
                RaHireGroupId = source.RaHireGroupId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                InsuranceCharge = source.InsuranceCharge,
                InsuranceRate = source.InsuranceRate,
                StartDtTime = Convert.ToDateTime(source.StartDtTime.ToString("dd-MMM-yy HH:mm")),
                EndDtTime = Convert.ToDateTime(source.EndDtTime.ToString("dd-MMM-yy HH:mm")),
                InsuranceTypeId = source.InsuranceTypeId,
                TariffType = source.TariffType
            };

        }

        #endregion

    }
}
