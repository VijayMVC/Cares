using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;


namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Partner InType Service
    /// </summary>
    public class BusinessPartnerInTypeService : IBusinessPartnerInTypeService
    {
        #region Private
        private readonly IBusinessPartnerInTypeRepository businessPartnerInTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerInTypeService(IBusinessPartnerInTypeRepository businessPartnerInTypeRepository)
        {
            this.businessPartnerInTypeRepository = businessPartnerInTypeRepository;

        }
        #endregion

        #region Public
        ///// <summary>
        ///// Find business partner individaul by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public BusinessPartnerInType FindBusinessPartnerIndividual(int id)
        //{
        //    return businessPartnerInTypeRepository.Find(id);
        //}
        /// <summary>
        /// Get Business Partner inType by Business Partner Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerInType FindBusinessPartnerInTypeById(long id)
        {
            return businessPartnerInTypeRepository.GetById(id);
        }
        #endregion
    }
}
