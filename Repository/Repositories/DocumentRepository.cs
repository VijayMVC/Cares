using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Document Repository
    /// </summary>
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Document> DbSet
        {
            get
            {
                return db.Documents;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Association check with document group
        /// </summary>
        public bool IsDocumentGroupAssocitedWithDocument(long documentGroupId)
        {
            return DbSet.Count(dbdocument => dbdocument.DocumentGroupId == documentGroupId) > 0;
        }
        #endregion
    }
}
