namespace Cares.Web.Models
{
    /// <summary>
    /// Pricing Strategy Web Model
    /// </summary>
    public class PricingStrategy
    {
        #region Public Properties
        /// <summary>
        /// PricingStrategy ID
        /// </summary>
        public int PricingStrategyId { get; set; }
        /// <summary>
        /// PricingStrategy Code
        /// </summary>
        public string PricingStrategyCode { get; set; }
        /// <summary>
        /// PricingStrategy Name
        /// </summary>
        public string PricingStrategyName { get; set; }
        #endregion
    }
}