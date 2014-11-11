using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.ReportModels;
using System.Collections.Generic;

namespace Cares.Implementation.ReportServices
{
    public class InsuranceRateReportService : IInsuranceRateReportService
    {
        #region Private

        private readonly IInsuranceRtRepository insuranceRtRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRateReportService(IInsuranceRtRepository insuranceRtRepository)
        {
            this.insuranceRtRepository = insuranceRtRepository;
        }

        #endregion
        #region Public

        public IEnumerable<InsuranceRateReportResponse> LoadInsuranceRateReport()
        {
            return insuranceRtRepository.GetInsuranceRateReportData();
        }
        
        #endregion

    }
}
