using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Chauffer Charge Repository
    /// </summary>
    public interface IChaufferChargeRepository : IBaseRepository<ChaufferCharge, long>
    {
        /// <summary>
        /// Get Chauffer Charge For Ra Billing
        /// </summary>
        IEnumerable<ChaufferCharge> GetForRaBilling(string tariffTypeCode, long desigGradeId, DateTime raRecCreatedDt);
    }
}
