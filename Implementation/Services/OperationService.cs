using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Operation Service
    /// </summary>
    public class OperationService : IOperationService
    {
        #region Private
        private readonly IOperationRepository operationRepository;
        #endregion
        #region Constructor
        public OperationService(IOperationRepository operationRepository)
        {
            this.operationRepository = operationRepository;
        }
        #endregion
        #region Public
        public IEnumerable<Operation> LoadAll()
        {
            return operationRepository.GetAll();
        }
        #endregion
    }
}
