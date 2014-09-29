
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Document Group Service Interface
    /// </summary>
    public interface IDocumentGroupService
    {

        /// <summary>
        /// Search Document Group
        /// </summary>
        DocumentGroupSearchRequestResponse SearchDocumentGroup(DocumentGroupSearchRequest request);

        /// <summary>
        /// Delete DocumentGroup by id
        /// </summary>
        void DeleteDocumentGroup(long documentGroupId);

        /// <summary>
        /// Add /Update Document Group
        /// </summary>
        DocumentGroup SaveDocumentGroup(DocumentGroup documentGroup);

    }
}
