using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaDriver Mapper
    /// </summary>
    public static class RaDriverMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaDriver CreateFrom(this DomainModels.RaDriver source)
        {
            return new RaDriver
            {
                RaDriverId = source.RaDriverId,
                RaMainId = source.RaMainId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                TariffType = source.TariffType,
                ChaufferId = source.ChaufferId,
                DesigGradeId = source.DesigGradeId,
                DriverName = source.DriverName,
                IsChauffer = source.IsChauffer,
                LicenseExpDt = source.LicenseExpDt,
                LicenseNo = source.LicenseNo,
                Rate = source.Rate,
                TotalCharge = source.TotalCharge
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaDriver CreateFrom(this RaDriver source)
        {
            return new DomainModels.RaDriver
            {
                RaDriverId = source.RaDriverId,
                RaMainId = source.RaMainId,
                ChargedDay = source.ChargedDay,
                ChargedHour = source.ChargedHour,
                ChargedMinute = source.ChargedMinute,
                EndDtTime = source.EndDtTime,
                StartDtTime = source.StartDtTime,
                TariffType = source.TariffType,
                ChaufferId = source.ChaufferId,
                DesigGradeId = source.DesigGradeId,
                DriverName = source.DriverName,
                IsChauffer = source.IsChauffer,
                LicenseExpDt = source.LicenseExpDt,
                LicenseNo = source.LicenseNo,
                Rate = source.Rate,
                TotalCharge = source.TotalCharge
            };

        }

        #endregion

    }
}
