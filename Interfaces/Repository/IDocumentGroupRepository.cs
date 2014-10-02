using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Document Group Repository Interface
    /// </summary>
    public interface IDocumentGroupRepository : IBaseRepository<DocumentGroup, int>
    {

        /// <summary>
        /// Search Document Group
        /// </summary>
        IEnumerable<DocumentGroup> SearchDocumentGroup(DocumentGroupSearchRequest request, out int rowCount);

        /// <summary>
        /// Document Group Code duplication check 
        /// </summary>
        bool DoesDocumentGroupCodeExists(DocumentGroup documentGroup);


    }
}

