using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
// ReSharper disable once InconsistentNaming
    public sealed class RACustomerDocumentRepository : BaseRepository<RaCustomerDocument>, IRACustomerDocumentRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RACustomerDocumentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaCustomerDocument> DbSet
        {
            get
            {
                return db.RaCustomerDocuments;
            }
        }
        #endregion
        #region Public

        /// <summary>
        ///  Business Partner Document Association check with document 
        /// </summary>
        public bool IsDocumentAssocitedWithRaCustomerDocument(long documentId)
        {
           return DbSet.Count(racustomerDocument => racustomerDocument.DocumentId == documentId) > 0;

        }
        #endregion
    }
}
