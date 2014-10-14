using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Document Group Repository
    /// </summary>
    public sealed class DocumentGroupRepository : BaseRepository<DocumentGroup>, IDocumentGroupRepository
    {
        #region privte
        /// <summary>
        /// Document Group Orderby clause for sorting 
        /// </summary>
        private readonly Dictionary<DocumentGroupByColumn, Func<DocumentGroup, object>> documentGroupOrderByClause = new Dictionary<DocumentGroupByColumn, Func<DocumentGroup, object>>
                    {
                        {DocumentGroupByColumn.Code, d => d.DocumentGroupCode},
                        {DocumentGroupByColumn.Name, c => c.DocumentGroupName}
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DocumentGroup> DbSet
        {
            get
            {
                return db.DocumentGroups;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Document Group for User Domain Key
        /// </summary>
        public override IEnumerable<DocumentGroup> GetAll()
        {
            return DbSet.Where(city => city.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Document Group By Id
        /// </summary>
        public DocumentGroup Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Search Document Group
        /// </summary>
        public IEnumerable<DocumentGroup> SearchDocumentGroup(DocumentGroupSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<DocumentGroup, bool>> query =
                documentGroup =>
                    (string.IsNullOrEmpty(request.DocumentGroupFilterText) ||
                     (documentGroup.DocumentGroupName.Contains(request.DocumentGroupFilterText)) ||
                     (documentGroup.DocumentGroupCode.Contains(request.DocumentGroupFilterText)));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(documentGroupOrderByClause[request.DocumentGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(documentGroupOrderByClause[request.DocumentGroupOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Document Group Code duplication check 
        /// </summary>
        public bool DoesDocumentGroupCodeExists(DocumentGroup documentGroup)
        {
            return
                DbSet.Count(
                    dbdocumentGroup =>
                        dbdocumentGroup.DocumentGroupCode == documentGroup.DocumentGroupCode &&
                        dbdocumentGroup.DocumentGroupId != documentGroup.DocumentGroupId) > 0;
        }

        #endregion
    }
}
