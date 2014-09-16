using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Legal Status Service
    /// </summary>
    public class BusinessLegalStatusService : IBusinessLegalStatusService
    {
        #region Private
        private readonly IBusinessLegalStatusRepository businessLegalStatusRepository;
        #endregion
        #region Constructor

        public BusinessLegalStatusService(IBusinessLegalStatusRepository businessLegalStatusRepository)
        {
            this.businessLegalStatusRepository = businessLegalStatusRepository;
        }
        #endregion
        #region Public
        public IEnumerable<BusinessLegalStatus> LoadAll()
        {
            return businessLegalStatusRepository.GetAll();
        }
        #endregion
    }
}
