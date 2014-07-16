using ApiModel=Cares.Web.Models;
using Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class FleetPoolMapper
    {
        #region Public
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

            #region Model To Entity
            /// <summary>
            ///  Create entity from web model
            /// </summary>
            public static FleetPool CreateFrom(this ApiModel.FleetPool source)
            {
                return new FleetPool
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
    }
}