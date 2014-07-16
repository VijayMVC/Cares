using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Pricing Strategy Interface
    /// </summary>
    public interface IPricingStrategyService
    {
        IQueryable<PricingStrategy> LoadAll();
    }
}
