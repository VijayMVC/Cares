using Cares.Web.Models;
using System.Linq;
using NrtTypeBaseDataResponse = Cares.Web.Models.NrtTypeBaseDataResponse;
using NrtTypeSearchRequestResponse = Cares.Models.ResponseModels.NrtTypeSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Nrt Type  Mapper  Model
    /// </summary>
    public static class NrtTypeMapper
    {
        #region Public
        /// <summary>
        /// Crete From web model
        /// </summary>
        public static Cares.Models.DomainModels.NrtType CreateFrom(this NrtType source)
        {
            return new Cares.Models.DomainModels.NrtType
            {
                NrtTypeId = source.NrtTypeId,
                NrtTypeCode = source.NrtTypeCode,
                NrtTypeName = source.NrtTypeName,
                Description = source.Description,
                NrtTypeKey = source.NrtTypeKey,
                StandardLifeTime = source.StandardLifeTime,
                VehicleStatusId = source.VehicleStatusId
            };
        }
        /// <summary>
        /// Crete From company Response domain model
        /// </summary>
        public static Models.NrtTypeSearchRequestResponse CreateFrom(this NrtTypeSearchRequestResponse source)
        {
            return new Models.NrtTypeSearchRequestResponse
            {
                NrtTypes = source.NrtTypes.Select(company => company.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }
        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static NrtType CreateFromm(this Cares.Models.DomainModels.NrtType source)
        {
            return new NrtType
            {
               NrtTypeId = source.NrtTypeId,
               NrtTypeCode = source.NrtTypeCode,
               NrtTypeName = source.NrtTypeName,
               Description = source.Description,
               NrtTypeKey = source.NrtTypeKey,
               StandardLifeTime = source.StandardLifeTime,
               VehicleStatusId = source.VehicleStatusId,
               VehicleStatusName=source.VehicleStatus.VehicleStatusName
            };
        }

        /// <summary>
        /// Crete From response model to web base data
        /// </summary>
        public static NrtTypeBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.NrtTypeBaseDataResponse source)
        {
            return new NrtTypeBaseDataResponse
            {
               VehicleStatuses = source.VehicleStatuses.Select(vehicle => vehicle.CreateFromm())
            };
        }

       
        #endregion
    }
}