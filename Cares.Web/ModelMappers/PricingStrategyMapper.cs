using Cares.Web.Models;

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
        public static PricingStrategy CreateFrom(this Cares.Models.DomainModels.PricingStrategy source)
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
        public static Cares.Models.DomainModels.PricingStrategy CreateFrom(this PricingStrategy source)
        {
            if (source != null)
            {
                return new Cares.Models.DomainModels.PricingStrategy
                {
                    PricingStrategyId = source.PricingStrategyId,
                    PricingStrategyName = source.PricingStrategyName,
                };
            }
            return new Cares.Models.DomainModels.PricingStrategy();
        }
        #endregion
    
    }
}