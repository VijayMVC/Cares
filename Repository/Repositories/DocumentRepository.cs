using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
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
        #region privte
        /// <summary>
        /// Document Orderby clause
        /// </summary>
        private readonly Dictionary<DocumentByColumn, Func<Document, object>> documentOrderByClause = new Dictionary<DocumentByColumn, Func<Document, object>>
                    {

                        {DocumentByColumn.Code, c => c.DocumentCode},
                        {DocumentByColumn.Name, n => n.DocumentName},
                        {DocumentByColumn.DocGroup, d=> d.DocumentGroup.DocumentGroupId}
                    };
        #endregion
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

        /// <summary>
        /// Search Document
        /// </summary>
        public IEnumerable<Document> SearchDocument(DocumentSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Document, bool>> query =
                document =>
                    (string.IsNullOrEmpty(request.DocumentCodeNameText) ||
                     (document.DocumentCode.Contains(request.DocumentCodeNameText)) ||
                     (document.DocumentName.Contains(request.DocumentCodeNameText))) &&
                    (!request.DocumentGroypId.HasValue || request.DocumentGroypId == document.DocumentGroupId) && (document.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(documentOrderByClause[request.DocumentOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(documentOrderByClause[request.DocumentOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Self-code duplication check
        /// </summary>
        public bool IsDocumentCodeExist(Document document)
        {
            return
                DbSet.Count(
                    dBdocument =>
                        dBdocument.DocumentCode == document.DocumentCode && dBdocument.DocumentId != document.DocumentId) >
                0;
        }

        /// <summary>
        /// Get detail object of document
        /// </summary>
        public Document GetDocumentWithDetail(long documentId)
        {
            return DbSet.Include(document => document.DocumentGroup)
               .FirstOrDefault(fleetPool => fleetPool.DocumentId == documentId);
        }
        #endregion
    }
}
