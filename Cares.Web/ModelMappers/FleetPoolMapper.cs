using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Fleet Pool Mapper 
    /// </summary>
    public static class FleetPoolMapper
    {
        #region Fleet Pool
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.FleetPool CreateFrom(this FleetPool source)
        {
            return new ApiModel.FleetPool
                   {
                       FleetPoolId = source.FleetPoolId,
                       FleetPoolCode = source.FleetPoolCode,
                       FleetPoolName = source.FleetPoolName,
                       ApproximateVehiclesAsgnd = source.ApproximateVehiclesAsgnd,
                       Description = source.FleetPoolDescription,
                       OperationId = source.Operation.OperationId,
                       OperationName = source.Operation.OperationName,
                       RegionId = source.Region.RegionId,
                       RegionName = source.Region.RegionName,
                       CountryId = source.Region.CountryId,
                       CountryName = source.Region.Country.CountryName,
                   };
        }

        /// <summary>
        /// Fleet Pool Drop Down
        /// </summary>
        public static ApiModel.FleetPoolDropDown CreateFromDropDown(this FleetPool source)
        {
            return new ApiModel.FleetPoolDropDown
            {
                FleetPoolId = source.FleetPoolId,
                FleetPoolCodeName = source.FleetPoolCode + " - " + source.FleetPoolName
            };
        }
        #endregion
        #region FleetPoolBase
        /// <summary>
        /// Fleet Pool Base Data Response
        /// </summary>
        public static ApiModel.FleetPoolBaseDataResponse CreateFrom(this FleetPoolBaseDataResponse source)
        {
            return new ApiModel.FleetPoolBaseDataResponse
             {
                 Operations = source.Operations.Select(operation => operation.CreateFrom()),
                 Regions = source.Regions.Select(region => region.CreateFrom()),
                 Countries = source.Countries.Select(country => country.CreateFrom())
             };
        }
        #endregion
        #region FleetPoolResponse

        /// <summary>
        /// Fleet Pool Response
        /// </summary>
        public static ApiModel.FleetPoolResponse CreateFrom(this FleetPoolResponse source)
        {
            return new ApiModel.FleetPoolResponse
            {
                FleetPools = source.FleetPools.Select(fleet => fleet.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        /// <summary>
        /// web model to domain model mapper
        /// </summary>
        public static FleetPool CreateFrom(this ApiModel.FleetPool source)
        {
            return new FleetPool
            {
                FleetPoolId = source.FleetPoolId,
                FleetPoolCode = source.FleetPoolCode,
                FleetPoolName = source.FleetPoolName,
                FleetPoolDescription = source.Description,
                ApproximateVehiclesAsgnd = source.ApproximateVehiclesAsgnd,
                OperationId = source.OperationId,
                RegionId = source.RegionId
            };
        }
        #endregion


    }
}