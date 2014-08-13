﻿using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class AreaMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static ApiModel.AreaDropDown CreateFrom(this Area source)
        {
            return new ApiModel.AreaDropDown()
            {
                AreaId = source.AreaId,
                AreaCodeName = source.AreaCode + " - "+source.AreaName,
                CityId = source.CityId
            };
        }
        #endregion        
        #endregion
    }
}