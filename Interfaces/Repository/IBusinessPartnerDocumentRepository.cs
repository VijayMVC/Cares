using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Document Repository interface
    /// </summary>
    public interface IBusinessPartnerDocumentRepository : IBaseRepository<BusinessPartnerDocument, long>
    {
        /// <summary>
        ///  Business Partner Document Association check with document 
        /// </summary>
        bool IsDocumentAssocitedWithBusinessPartnerDocument(long documentId);
    }
}
