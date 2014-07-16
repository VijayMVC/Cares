using System.Linq;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Payment Term Service Interface
    /// </summary>
    public interface IPaymentTermService
    {
        IQueryable<PaymentTerm> LoadAll();
    }
}
