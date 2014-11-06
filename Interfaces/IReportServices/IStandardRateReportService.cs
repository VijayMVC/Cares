
using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Interfaces.IReportServices
{
    public interface IStandardRateReportService
    {
        IEnumerable<StandardRate> LoadStandardrateDetail();
    }
}
