using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    /// <summary>
    /// Pricing Strategy Service
    /// </summary>
    public class PricingStrategyService : IPricingStrategyService
    {
        #region Private
        private readonly IPricingStrategyRepository pricingStrategyRepository;
        #endregion
        #region Constructor

        public PricingStrategyService(IPricingStrategyRepository pricingStrategyRepository)
        {
            this.pricingStrategyRepository = pricingStrategyRepository;
        }
        #endregion
        #region Public
        public IQueryable<PricingStrategy> LoadAll()
        {
            return pricingStrategyRepository.GetAll();
        }
        #endregion
    }
}
