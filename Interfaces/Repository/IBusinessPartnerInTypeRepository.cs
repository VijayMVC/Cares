using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner InType Repository Interface
    /// </summary>
    public interface IBusinessPartnerInTypeRepository : IBaseRepository<BusinessPartnerInType, long>
    {
        ///// <summary>
        ///// Get Busienss partner Individual by Name and Id
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //BusinessPartnerIndividual GetBusinessPartnerIndividualByName(string name, int id);
        /// <summary>
        /// Get business partner intype by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BusinessPartnerInType GetById(long id);
    }
}
