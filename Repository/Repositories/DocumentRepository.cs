using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
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
            return DbSet.Count(documentm => documentm.DocumentGroupId == documentGroupId) > 0;
        }
        #endregion
    }
}
