using Cares.Models.DomainModels;

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
    }
}
