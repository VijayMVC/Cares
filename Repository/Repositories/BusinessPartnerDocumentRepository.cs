using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Document Repository
    /// </summary>
    public sealed class BusinessPartnerDocumentRepository : BaseRepository<BusinessPartnerDocument>, IBusinessPartnerDocumentRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerDocumentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerDocument> DbSet
        {
            get
            {
                return db.BusinessPartnerDocuments;
            }
        }
        #endregion
        #region Public

        /// <summary>
        ///  Business Partner Document Association check with document 
        /// </summary>
        public bool IsDocumentAssocitedWithBusinessPartnerDocument(long documentId)
        {
            return DbSet.Count(businessPartnerdocs =>businessPartnerdocs.UserDomainKey==UserDomainKey && businessPartnerdocs.DocumentId == documentId) > 0;
        }
        #endregion
    }
}
