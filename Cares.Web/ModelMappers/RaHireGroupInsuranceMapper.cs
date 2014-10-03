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
                TariffType = source.TariffType
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
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                InsuranceTypeId = source.InsuranceTypeId,
                TariffType = source.TariffType
            };

        }

        #endregion

    }
}
