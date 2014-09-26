using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Helpers
{
    /// <summary>
    /// Ra Driver Helper Interface
    /// </summary>
    public interface IRaDriverHelper
    {
        /// <summary>
        /// Calculate Ra Driver Helper
        /// </summary>
        RaDriver CalculateCharge(DateTime rACreatedDate, DateTime startDtTime, DateTime endDtTime, long desigGradeId, bool isChauffer,
            long operationId, List<TariffType> oTariffTypeList);

    }
}
