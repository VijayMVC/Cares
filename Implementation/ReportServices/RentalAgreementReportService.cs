using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

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
        public RaMain GetRentalAgreementReportDetail(long rAMainId)
        {
            var retVal = rentalAgreementRepository.FindRa(rAMainId);
            return retVal;


        }
        #endregion
    }
}
