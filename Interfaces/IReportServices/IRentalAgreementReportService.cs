
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IReportServices
{
    public interface IRentalAgreementReportService
    {
        /// <summary>
        /// Get Details for Rental Agreement Report Generation
        /// </summary>
        RaMain GetRentalAgreementReportDetail(long rAMainId);

    }
}
