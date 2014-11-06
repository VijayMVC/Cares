using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Implementation.ReportServices
{
    public class StandardRateReportService : IStandardRateReportService
    {
        #region Private

        private readonly IStandardRateRepository standardRateRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateReportService(IStandardRateRepository standardRateRepository)
        {
            this.standardRateRepository = standardRateRepository;
        }

        #endregion
        #region Public

        public IEnumerable<StandardRate> LoadStandardrateDetail()
        {
            return standardRateRepository.GetAll();
        }

        #endregion
    }
}
