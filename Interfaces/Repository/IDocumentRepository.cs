using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Document Repository interface
    /// </summary>
    public interface IDocumentRepository : IBaseRepository<Document, long>
    {
        /// <summary>
        /// Association check with document group
        /// </summary>
        bool IsDocumentGroupAssocitedWithDocument(long documentGroupId );

        /// <summary>
        /// Search Document
        /// </summary>
        IEnumerable<Document> SearchDocument(DocumentSearchRequest request, out int rowCount);

        /// <summary>
        /// Get detail object of document
        /// </summary>
        Document GetDocumentWithDetail(long documentId);

        /// <summary>
        /// Self-code duplication check
        /// </summary>
        bool IsDocumentCodeExist(Document document);
    }
}
