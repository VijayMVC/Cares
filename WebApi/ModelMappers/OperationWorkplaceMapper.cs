﻿using Cares.Models.DomainModels;
using Cares.WebApi.Models;

namespace Cares.WebApi.ModelMappers
{
    /// <summary>
    /// Operation Workplace Mapper
    /// </summary>
    public static class OperationWorkplaceMapper
    {
        /// <summary>
        /// Create WebApiOperationWorkplace from domain model of Operation workplace
        /// </summary>
        public static WebApiOperationWorkplace CreateFrom(this OperationsWorkPlace operaOperationsWorkPlace)
        {
            return new WebApiOperationWorkplace
            {
                OperationWorkplaceId = operaOperationsWorkPlace.OperationsWorkPlaceId,
                LocationName = operaOperationsWorkPlace.LocationName
            };
        }
    }
}