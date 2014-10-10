using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Non Revenue Ticket Service Interface
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface INRTService
    {
        /// <summary>
        /// Load Non Revenue Ticket Base data
        /// </summary>
        NRTBaseResponse GetBaseData();

        /// <summary>
        /// Get Additional Charge For NRT
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        IEnumerable<AdditionalChargeForNrt> AdditionalChargeForNrt(DateTime startDt, long vehicleId);

        /// <summary>
        /// Save NRT 
        /// </summary>
        /// <param name="nrtVehicle"></param>
        /// <returns></returns>
        long SaveNrt(NrtVehicle nrtVehicle);
    }
}
