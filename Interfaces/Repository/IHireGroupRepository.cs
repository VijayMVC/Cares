using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Hire Group Interface
    /// </summary>
    public interface IHireGroupRepository : IBaseRepository<HireGroup, long>
    {
        TariffRateDetailResponse GetHireGroupDetails(TariffRateDetailRequest tariffRateDetailRequest);
    }
}
