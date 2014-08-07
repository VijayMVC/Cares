using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Company Service
    /// </summary>
    public class CompanyService : ICompanyService
    {
        #region Private
        private readonly ICompanyRepository companyRepository;
        #endregion
        #region Constructor

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        #endregion
        #region Public
        public IQueryable<Company> LoadAll()
        {
            return companyRepository.GetAll();
        }
        #endregion
    }
}
