using Cares.Web.Models;
using System.Linq;
using NrtTypeBaseDataResponse = Cares.Web.Models.NrtTypeBaseDataResponse;
using NrtTypeSearchRequestResponse = Cares.Models.ResponseModels.NrtTypeSearchRequestResponse;
using ApiModel = Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
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
        public static DomainModels.NrtType CreateFrom(this NrtType source)
        {
            return new DomainModels.NrtType
            {
                NrtTypeId = source.NrtTypeId,
                NrtTypeCode = source.NrtTypeCode.Trim(),
                NrtTypeName = source.NrtTypeName,
                Description = source.Description,
                NrtTypeKey = source.NrtTypeKey,
                StandardLifeTime = source.StandardLifeTime,
                VehicleStatusId = source.VehicleStatusId
            };
        }

        /// <summary>
        /// Crete [dropdown] From Domain Model 
        /// </summary>
        public static NrtTypeDropDown CreateFrom(this DomainModels.NrtType source)
        {
            return new NrtTypeDropDown
            {
                NrtTypeId = source.NrtTypeId,
                NrtTypeCodeName = source.NrtTypeCode + " - " + source.NrtTypeName,
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
        public static NrtType CreateFromm(this DomainModels.NrtType source)
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
                VehicleStatusName = source.VehicleStatus.VehicleStatusName
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