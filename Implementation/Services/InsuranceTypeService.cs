using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Insurance Type Service
    /// </summary>
    public class InsuranceTypeService : IInsuranceTypeService
    {
        #region Private
        
        private readonly IInsuranceTypeRepository insuranceTypeRepository;

        #endregion

        #region Constructors

        public InsuranceTypeService(IInsuranceTypeRepository insuranceTypeRepository)
        {
            if (insuranceTypeRepository == null)
            {
                throw new ArgumentNullException("insuranceTypeRepository");
            }

            this.insuranceTypeRepository = insuranceTypeRepository;
        }

        #endregion

        #region Public
        
        /// <summary>
        /// Get All For RA
        /// </summary>
        public IEnumerable<InsuranceType> GetAllForRa()
        {
            return insuranceTypeRepository.GetAll();
        }

        #endregion
    }
}
