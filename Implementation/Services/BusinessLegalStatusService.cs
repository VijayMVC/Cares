using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
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
        public IQueryable<BusinessLegalStatus> LoadAll()
        {
            return businessLegalStatusRepository.GetAll();
        }
        #endregion
    }
}
