using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Company Service Interface
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Load all Documents
        /// </summary>
        IEnumerable<Document> LoadAll();

        /// <summary>
        /// Delete Document
        /// </summary>
        void DeleteDocument(long documentId);

        /// <summary>
        /// Load Base data of Document
        /// </summary>
        DocumentBaseDataResponse LoadDocumentBaseData();

        /// <summary>
        /// Search Document
        /// </summary>
        DocumentSearchRequestResponse SearchDocument(DocumentSearchRequest request);

        /// <summary>
        /// Add / Update Document
        /// </summary>
        Document AddUpdateDocument(Document document);
    }
}
