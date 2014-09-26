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
    /// Calculates Rental Charge
    /// </summary>
    public class RentalCharge : IRentalCharge
    {
        private readonly IStandardRateRepository standardRateRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalCharge(IStandardRateRepository standardRateRepository)
        {
            if (standardRateRepository == null) throw new ArgumentNullException("standardRateRepository");
            
            this.standardRateRepository = standardRateRepository;
        }

        /// <summary>
        /// Calculate Charge
        /// </summary>
        public RaHireGroup CalculateCharge(DateTime recCreatedDate, DateTime rAStDate, DateTime rAEndDate, DateTime stDate, DateTime eDate, 
            Int64 operationId, Int64 hireGroupDetailId, Int32 outOdometer, Int32 inOdometer, List<TariffType> oTariffTypeList)
        {
            PricingStrategy objPs = PricingStrategyFactory.GetPricingStrategy(recCreatedDate, rAStDate, rAEndDate, operationId, oTariffTypeList);
            if (objPs == null)
            {
                throw new CaresException("Tarrif Type not defined", null);
            }

            List<StandardRate> standardRates = standardRateRepository.GetForRaBilling(objPs.TariffType.TariffTypeCode, hireGroupDetailId, recCreatedDate).ToList();

            if (standardRates.Count == 0)
            {
                throw new CaresException("Standart Tariff Rate not defined", null);
            }

            StandardRate otStRate = standardRates[0];

            RaHireGroup tmp = objPs.CalculateRentalCharge(stDate, eDate, otStRate);

            // need to get RA vehicle as well for calculating Excess Mileage Charge for edit case
            tmp.TotalExcMileage = objPs.GetExcessMileage(outOdometer, inOdometer, tmp.AllowedMileage ?? 0);
            tmp.TotalExcMileageCharge = objPs.GetExcessMileageCharge(tmp.TotalExcMileage, (float)tmp.ExcessMileageRt);

            return tmp;
        }
    }
}
