using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Individual Repository Interface
    /// </summary>
    public interface IBusinessPartnerIndividualRepository : IBaseRepository<BusinessPartnerIndividual, long>
    {
        /// <summary>
        /// Get Busienss partner Individual by Name and Id
        /// </summary>
        BusinessPartnerIndividual GetBusinessPartnerIndividualByName(string name, int id);

        /// <summary>
        /// Get business partner individual by Id
        /// </summary>
        BusinessPartnerIndividual GetById(long id);

        /// <summary>
        /// Association check of Occupation Type and Business Partner Individual
        /// </summary>
        bool IsOccupationTypeAssociatedWithBusinessPartnerIndividual(long occupationTypeId);
    }
}
