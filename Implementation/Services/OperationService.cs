
using System.Collections.Generic;
using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
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
