using System;
using System.Collections.Generic;
using System.Linq;
using Cares.ExceptionHandling;
using Cares.Interfaces.Helpers;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    /// <summary>
    /// Ra Driver Helper
    /// </summary>
    public class RaDriverHelper : IRaDriverHelper
    {
        private readonly IChaufferChargeRepository chaufferChargeRepository;
        private readonly IAdditionalDriverChargeRepository additionalDriverChargeRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public RaDriverHelper(IChaufferChargeRepository chaufferChargeRepository, IAdditionalDriverChargeRepository additionalDriverChargeRepository)
        {
            if (chaufferChargeRepository == null) throw new ArgumentNullException("chaufferChargeRepository");
            if (additionalDriverChargeRepository == null)
                throw new ArgumentNullException("additionalDriverChargeRepository");
            
            this.chaufferChargeRepository = chaufferChargeRepository;
            this.additionalDriverChargeRepository = additionalDriverChargeRepository;
        }

        /// <summary>
        /// Calculate Ra Driver Charge
        /// </summary>
        public RaDriver CalculateCharge(DateTime rACreatedDate, DateTime startDtTime, DateTime endDtTime, long desigGradeId, bool isChauffer,
            long operationId, List<TariffType> oTariffTypeList)
        {

            PricingStrategy objPs = PricingStrategyFactory.GetPricingStrategy(rACreatedDate, startDtTime, endDtTime, operationId, oTariffTypeList);
            if (objPs == null)
            {
                throw new CaresException("TarrifType not defined", null);
            }

            RaDriver tmp;
            if (isChauffer)
            {
                List<ChaufferCharge> chaufferCharges = chaufferChargeRepository.
                    GetForRaBilling(objPs.TariffType.TariffTypeCode, Convert.ToInt64(desigGradeId), rACreatedDate).ToList();

                if (chaufferCharges.Count == 0)
                {
                    throw new CaresException("Chauffer Tariff Rate not defined", null);
                }

                ChaufferCharge oChfRate = chaufferCharges[0];

                tmp = objPs.CalculateChaufferCharge(startDtTime, endDtTime, oChfRate);
            }
            else
            {
                List<AdditionalDriverCharge> additionalDriverCharges = additionalDriverChargeRepository.
                    GetForRaBilling(objPs.TariffType.TariffTypeCode, rACreatedDate).ToList();

                if (additionalDriverCharges.Count == 0)
                {
                    throw new CaresException("Additional Driver Charge not defined", null);
                }

                AdditionalDriverCharge oAddDrvRate = additionalDriverCharges[0];

                tmp = objPs.CalculateAddDriverCharge(startDtTime, endDtTime, oAddDrvRate);
            }

            return tmp;

        }

    }
}
