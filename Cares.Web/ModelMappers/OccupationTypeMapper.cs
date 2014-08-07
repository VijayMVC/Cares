﻿using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Occupation Type Mapper
    /// </summary>
    public static class OccupationTypeMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OccupationType CreateFrom(this OccupationType source)
            {
                return new ApiModel.OccupationType
                {
                    OccupationTypeId = source.OccupationTypeId,
                    OccupationTypeName = source.OccupationTypeName,
                    OccupationTypeCode = source.OccupationTypeCode
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static OccupationType CreateFrom(this ApiModel.OccupationType source)
        {
            return new OccupationType
            {
                OccupationTypeId = source.OccupationTypeId,
                OccupationTypeName = source.OccupationTypeName,
                OccupationTypeCode = source.OccupationTypeCode
            };
        }
        
        #endregion
        #endregion
    }
}