using System;
using System.Linq;
using Cares.Web.Models;
using DomainModels = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Hire Group Detail Mapper
    /// </summary>
    public static class HireGroupDetailMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.HireGroupDetail CreateFrom(this DomainModels.HireGroupDetail source)
        {
            //float t = source.StandardRate != null
            //    ? float.Parse(source.StandardRate.Where(
            //            x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
            //            .Select(x => x.ExcessMileageChrg).SingleOrDefault()
            //            .ToString()!=null?source.StandardRate.Where(
            //            x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
            //            .Select(x => x.ExcessMileageChrg).SingleOrDefault()
            //            .ToString():string.Empty )
            //    : 0;
            //var nn = (source.StandardRate.Where(
            //    x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
            //    .Select(x => x.ExcessMileageChrg).SingleOrDefault()).ToString();
            return new HireGroupDetail
            {
                HireGroupDetailId = source.HireGroupDetailId,
                HireGroup = source.HireGroup != null
                        ? source.HireGroup.HireGroupCode + " - " + source.HireGroup.HireGroupName
                        : string.Empty,
                VehicleMake = source.VehicleMake != null
                        ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName
                        : string.Empty,
                VehicleModel = source.VehicleModel != null
                        ? source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName
                        : string.Empty,
                VehicleCategory = source.VehicleCategory != null
                        ? source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName
                        : string.Empty,
                ModelYear = source.ModelYear,
                AllowMileage = source.StandardRate != null
                ? float.Parse(source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.AllowedMileage).SingleOrDefault()
                        .ToString() != null ? source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.AllowedMileage).SingleOrDefault()
                        .ToString() : string.Empty) : 0,
                ExcessMileageCharge = source.StandardRate != null
                ? float.Parse(source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.ExcessMileageChrg).SingleOrDefault()
                        .ToString()!=null?source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.ExcessMileageChrg).SingleOrDefault()
                        .ToString():string.Empty ):0,
                StandardRt = source.StandardRate != null
                ? float.Parse(source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.StandardRt).SingleOrDefault()
                        .ToString()!=null?source.StandardRate.Where(
                        x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0)
                        .Select(x => x.StandardRt).SingleOrDefault()
                        .ToString():string.Empty )
                : 0,
               
                StartDate = source.StandardRate != null?source.StandardRate.Where(x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0).Select(x => x.StandardRtStartDt).SingleOrDefault():DateTime.Now,
                EndDate = source.StandardRate != null ? source.StandardRate.Where(x => x.HireGroupDetailId == source.HireGroupDetailId && x.ChildStandardRtId == 0).Select(x => x.StandardRtEndDt).SingleOrDefault() : DateTime.Now,
            };
        }
        #endregion
    }
}