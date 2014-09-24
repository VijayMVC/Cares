using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.Common;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    public class PricingStrategyFactory
    {
        public PricingStrategyFactory()
        {
        }

        public static PricingStrategy GetPricingStrategy(DateTime RACreatedDate, DateTime StartDate, DateTime EndDate, Int64 OperationID, List<TariffType> oTariffTypeList)
        {
            TariffType CandidateTariffType = new TariffType();
            CandidateTariffType = TariffTypeHelper.GetTariffType(RACreatedDate, StartDate, EndDate, OperationID, oTariffTypeList);


            PricingStrategy objPS = null;
            if (CandidateTariffType == null)
                return objPS;
            if (CandidateTariffType.PricingStrategyId == (int)PricingStrategyEnum.Fixed)
                objPS = new FixedPricingStrategy(CandidateTariffType);
            else if (CandidateTariffType.PricingStrategyId == (int)PricingStrategyEnum.ProRate)
                objPS = new FixedPricingStrategy(CandidateTariffType);
            else
                objPS = null;

            return objPS;
        }

    }
}
