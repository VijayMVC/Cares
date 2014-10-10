using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Additional Charge Repository
    /// </summary>
    public interface IAdditionalChargeRepository : IBaseRepository<AdditionalCharge, long>
    {
        /// <summary>
        /// Get Additional Charges By Addition Charge Type Id
        /// </summary>
        /// <param name="additionChargeTypeId"></param>
        /// <returns></returns>
        IEnumerable<AdditionalCharge> GetAdditionalChargesByAdditionChargeTypeId(long additionChargeTypeId);

        /// <summary>
        /// Get All For RA
        /// </summary>
        IEnumerable<AdditionalCharge> GetAllForRa();

        /// <summary>
        /// Get Additional Charge For NRT
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        IEnumerable<AdditionalChargeForNrt> AdditionalChargeForNrt(DateTime startDt, Vehicle vehicle);
    }
}
