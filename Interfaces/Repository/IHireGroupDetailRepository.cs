using System.Linq;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Hire Group Detail Interface
    /// </summary>
    public interface IHireGroupDetailRepository: IBaseRepository<HireGroupDetail, long>
    {
        IQueryable<HireGroupDetail> GetHireGroupDetails(TariffRateDetailRequest tariffRateDetailRequest);
    }
}
