
using System.Collections.Generic;
using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    /// <summary>
    /// Business Partner Company Service
    /// </summary>
    public class BusinessPartnerCompanyService : IBusinessPartnerCompanyService
    {
        #region Private
        private readonly IBusinessPartnerCompanyRepository businessPartnerCompanyRepository;
        #endregion
        #region Constructor

        public BusinessPartnerCompanyService(IBusinessPartnerCompanyRepository businessPartnerCompanyRepository)
        {
            this.businessPartnerCompanyRepository = businessPartnerCompanyRepository;
        }

        #endregion
        #region Public
        public IEnumerable<BusinessPartnerCompany> LoadAll()
        {
            return businessPartnerCompanyRepository.GetAll();
        }
        #endregion
    }
}
