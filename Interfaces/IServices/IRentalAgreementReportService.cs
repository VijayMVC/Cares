
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;

namespace Cares.Interfaces.IServices
{
    public interface IRentalAgreementReportService
    {
        /// <summary>
        /// Get Details for Rental Agreement Report Generation
        /// </summary>
        List<RaMain> GetRentalAgreementReportDetail();

    }
}
