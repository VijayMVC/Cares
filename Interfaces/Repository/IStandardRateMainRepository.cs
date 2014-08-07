using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;


namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Standard Rate Main Interface
    /// </summary>
    public interface IStandardRateMainRepository : IBaseRepository<StandardRateMain, long>
    {
        /// <summary>
        ///  Get all Tarrif Rates, based on filters
        /// </summary>
        TariffRateResponse GetTariffRates(TariffRateRequest tariffRateRequest);
    }
}
