using Cares.Models.DomainModels;
using System.Collections.Generic;
using Cares.Models.ReportModels;

namespace Cares.Interfaces.IReportServices
{
    public interface IInsuranceRateReportService
    {
        IEnumerable<InsuranceRateReportResponse> LoadInsuranceRateReport();
    }
}
