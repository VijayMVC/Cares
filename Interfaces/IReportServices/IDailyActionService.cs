using Cares.Models.DomainModels;
using System.Linq;

namespace Cares.Interfaces.IReportServices
{
    public interface IDailyActionService
    {
        IQueryable<RaHireGroup> LoadDailyActionReportDetail();
    }
}
