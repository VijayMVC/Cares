using System.Linq;
using Models.ResponseModels;
using ApiModel=Cares.Web.Models;
using Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Fleet Pool Mapper 
    /// </summary>
    public static class FleetPoolMapper
    {
        #region Fleet Pool
        #region Entity To Model
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
                Operation = source.Operation.CreateFrom(),
                Region = source.Region.CreateFrom()
            };
        }
        #endregion     
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
                 Regions = source.Regions.Select(region => region.CreateFrom())
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

        #endregion
    }
}