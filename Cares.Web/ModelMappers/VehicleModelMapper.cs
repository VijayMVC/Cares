﻿using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Model Mapper
    /// </summary>
    public static class VehicleModelMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleModelDropDown CreateFrom(this Cares.Models.DomainModels.VehicleModel source)
        {
            return new VehicleModelDropDown
            {
                VehicleModeld = source.VehicleModelId,
                VehicleModelName = source.VehicleModelName,
                VehicleModelCode = source.VehicleModelCode
            };
        }

        #endregion
    }
}