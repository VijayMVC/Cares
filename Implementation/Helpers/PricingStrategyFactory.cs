using System;
using System.Collections.Generic;
using Cares.Models.Common;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    /// <summary>
    /// Pricing Strategy Factory
    /// </summary>
    public class PricingStrategyFactory
    {
        /// <summary>
        /// Returns Pricing Strategy based on duration, opration and Tariff Type
        /// </summary>
        public static PricingStrategy GetPricingStrategy(DateTime rACreatedDate, DateTime startDate, DateTime endDate, Int64 operationId, List<TariffType> oTariffTypeList)
        {
            TariffType candidateTariffType = TariffTypeHelper.GetTariffType(rACreatedDate, startDate, endDate, operationId, oTariffTypeList);


            PricingStrategy objPs;
            if (candidateTariffType == null)
                return null;
            if (candidateTariffType.PricingStrategyId == (int)PricingStrategyEnum.Fixed)
                objPs = new FixedPricingStrategy(candidateTariffType);
            else if (candidateTariffType.PricingStrategyId == (int)PricingStrategyEnum.ProRate)
                objPs = new ProRatePricingStrategy(candidateTariffType);
            else
                objPs = null;

            return objPs;
        }

    }
}
