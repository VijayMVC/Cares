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
        public static PricingStrategyDropDown CreateFrom(this DomainModels.PricingStrategy source)
        {
            return new PricingStrategyDropDown
            {
                PricingStrategyId = source.PricingStrategyId,
                PricingStrategyCodeName = source.PricingStrategyCode + " - " + source.PricingStrategyName,
            };
        }
        #endregion

    }
}