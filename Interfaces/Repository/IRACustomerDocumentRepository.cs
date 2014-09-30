using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Document Repository interface
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface IRACustomerDocumentRepository : IBaseRepository<RaCustomerDocument, long>
    {
        /// <summary>
        ///  Business Partner Document Association check with document 
        /// </summary>
        bool IsDocumentAssocitedWithRaCustomerDocument(long documentId);
    }
}
