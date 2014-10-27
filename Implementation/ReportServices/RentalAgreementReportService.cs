using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;

namespace Cares.Implementation.ReportServices
{
    /// <summary>
    /// Company Service
    /// </summary>
    public class RentalAgreementReportService : IRentalAgreementReportService
    {
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IRentalAgreementRepository rentalAgreementRepository;
     
        #endregion
        #region Constructor
        /// <summary>
        ///  Company Constructor
        /// </summary>
        public RentalAgreementReportService(IRentalAgreementRepository rentalAgreementRepository)
        {
            this.rentalAgreementRepository = rentalAgreementRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Details for Rental Agreement Report Generation
        /// </summary>
        public List<RaMain> GetRentalAgreementReportDetail()
        {
            return rentalAgreementRepository.GetRentalAgreementReport();
        }
        #endregion
    }
}
