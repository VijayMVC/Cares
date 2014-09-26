using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Helpers
{
    /// <summary>
    /// Rental Charge Helper Interface
    /// </summary>
    public interface IRentalCharge
    {
        /// <summary>
        /// Calculate Rental Charge
        /// </summary>
        RaHireGroup CalculateCharge(DateTime recCreatedDate, DateTime rAStDate, DateTime rAEndDate, DateTime stDate, DateTime eDate,
            long operationId, long hireGroupDetailId, int outOdometer, int inOdometer, List<TariffType> oTariffTypeList);

    }
}
