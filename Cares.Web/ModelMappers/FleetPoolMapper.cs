using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class FleetPoolMapper
    {
        #region Public
            #region Entity To Model
            /// <summary>
            ///  Create web model from entity
            /// </summary>
            public static FleetPool CreateFrom(this global::Models.DomainModels.FleetPool source)
            {
                return new FleetPool
                {
                    FleetPoolId = source.FleetPoolId,
                    FleetPoolCode = source.FleetPoolCode,
                    FleetPoolName = source.FleetPoolName,
                    FleetPoolDescription = source.FleetPoolDescription,
                    IsActive = source.IsActive,
                    IsPrivate = source.IsPrivate,
                    IsReadOnly = source.IsReadOnly,
                    IsDeleted = source.IsDeleted,
                    OperationId = source.OperationId,
                    RegionId = source.RegionId,
                    UserDomainKey = source.UserDomainKey
                };
            }
            #endregion

            #region Model To Entity
            /// <summary>
            ///  Create entity from web model
            /// </summary>
            public static global::Models.DomainModels.FleetPool CreateFrom(this FleetPool source)
            {
                return new global::Models.DomainModels.FleetPool
                {
                    FleetPoolId = source.FleetPoolId,
                    FleetPoolCode = source.FleetPoolCode,
                    FleetPoolName = source.FleetPoolName,
                    FleetPoolDescription = source.FleetPoolDescription,
                    IsActive = source.IsActive,
                    IsPrivate = source.IsPrivate,
                    IsReadOnly = source.IsReadOnly,
                    IsDeleted = source.IsDeleted,
                    OperationId = source.OperationId,
                    RegionId = source.RegionId,
                    UserDomainKey = source.UserDomainKey
                };
            }
            #endregion
        #endregion
    }
}