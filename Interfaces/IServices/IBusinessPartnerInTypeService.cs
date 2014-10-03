
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    ///  Business Partner In Type Service Interface
    /// </summary>
    public interface IBusinessPartnerInTypeService
    {
         BusinessPartnerInType FindBusinessPartnerInTypeById(long id);
    }
}
