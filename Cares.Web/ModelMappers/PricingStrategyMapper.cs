using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Pricing Strategy Mapper
    /// </summary>
    public static class PricingStrategyMapper
    {
          #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static PricingStrategy CreateFrom(this DomainModels.PricingStrategy source)
        {
            return new PricingStrategy
            {
                PricingStrategyId = source.PricingStrategyId,
                PricingStrategyName = source.PricingStrategyName,
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.PricingStrategy CreateFrom(this PricingStrategy source)
        {
            if (source != null)
            {
                return new DomainModels.PricingStrategy
                {
                    PricingStrategyId = source.PricingStrategyId,
                    PricingStrategyName = source.PricingStrategyName,
                };
            }
            return new DomainModels.PricingStrategy();
        }
        #endregion
    
    }
}