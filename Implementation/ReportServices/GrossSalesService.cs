using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.ReportModels;
using System.Collections.Generic;

namespace Cares.Implementation.ReportServices
{
    public class GrossSalesService : IGrossSalesService
    {
        #region Private

        private readonly IRentalAgreementRepository rentalAgreementRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public GrossSalesService(IRentalAgreementRepository rentalAgreementRepository)
        {
            this.rentalAgreementRepository = rentalAgreementRepository;
        }

        #endregion
        #region Public

        public IEnumerable<GrossSalesReportResponse> LoadGrossSalesReport()
        {
            return rentalAgreementRepository.GetGrossSalesReport();
        }
        #endregion
    }
}
