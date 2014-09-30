using System;
using System.Globalization;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Implementation.Services
{
    /// <summary>
    /// Document Service
    /// </summary>
    public class DocumentService : IDocumentService
    {   
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IDocumentRepository documentRepository;
        private readonly IBusinessPartnerDocumentRepository businessPartnerDocumentRepository;
        private readonly IDocumentGroupRepository documentGroupRepository;
        private readonly IRACustomerDocumentRepository raCustomerDocumentRepository;

       
        /// <summary>
        /// Set Document Properties while adding new instance
        /// </summary>
        private void SetDocumentProperties(Document documentRequest, Document dbVersion)
        {
            dbVersion.RecCreatedBy =
                dbVersion.RecLastUpdatedBy = documentRepository.LoggedInUserIdentity;
            dbVersion.RecCreatedDt = dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = 0;
            dbVersion.UserDomainKey = 1;
            dbVersion.DocumentCode = documentRequest.DocumentCode;
            dbVersion.DocumentName = documentRequest.DocumentName;
            dbVersion.DocumentDescription = documentRequest.DocumentDescription;
            dbVersion.DocumentGroupId = documentRequest.DocumentGroupId;
        }

        /// <summary>
        /// Update Document Properties while updating the instance
        /// </summary>
        private void UpdateDocumentProperties(Document documentRequest, Document dbVersion)
        {
            dbVersion.RecLastUpdatedBy = documentRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DocumentCode = documentRequest.DocumentCode;
            dbVersion.DocumentName = documentRequest.DocumentName;
            dbVersion.DocumentDescription = documentRequest.DocumentDescription;
            dbVersion.DocumentGroupId = documentRequest.DocumentGroupId;
        }

        /// <summary>
        /// Check Document association with other entites before deletion
        /// </summary>
        private void CheckDocumentAssociations(long documentId)
        {
            // Document -BP Document association checking
            if (businessPartnerDocumentRepository.IsDocumentAssocitedWithBusinessPartnerDocument(documentId))
                throw new CaresException(Resources.BusinessPartner.Document.DocumentIsAssociatedWithBPDocumentEror);

            // Document- RA Customer Document association checking
            if (raCustomerDocumentRepository.IsDocumentAssocitedWithRaCustomerDocument(documentId))
                throw new CaresException(Resources.BusinessPartner.Document.DocumentIsAssociatedWithRACustomerDocumentError);
            
        }


        #endregion
        #region Constructor
        /// <summary>
        ///  Document Constructor
        /// </summary>
        public DocumentService(IDocumentRepository documentRepository, IDocumentGroupRepository documentGroupRepository,
            IBusinessPartnerDocumentRepository businessPartnerDocumentRepository, IRACustomerDocumentRepository raCustomerDocumentRepository)
        {
            this.documentRepository = documentRepository;
            this.documentGroupRepository = documentGroupRepository;
            this.businessPartnerDocumentRepository = businessPartnerDocumentRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Base data of Document
        /// </summary>
        public DocumentBaseDataResponse LoadDocumentBaseData()
        {
            return new DocumentBaseDataResponse
            {
                DocumentGroups = documentGroupRepository.GetAll()
            };
        }

        /// <summary>
        /// Delete Document
        /// </summary>
        public void DeleteDocument(long documentId)
        {
            Document dbversion = documentRepository.Find(documentId);
            CheckDocumentAssociations(documentId);
            if (dbversion == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Document with Id {0} not found!", documentId));
                }
            documentRepository.Delete(dbversion);
            documentRepository.SaveChanges();                
        }


        /// <summary>
        /// Search Document
        /// </summary>
        public DocumentSearchRequestResponse SearchDocument(DocumentSearchRequest request)
        {
            int rowCount;
            return new DocumentSearchRequestResponse
            {
                Documents = documentRepository.SearchDocument(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Add / Update Document
        /// </summary>
        public Document AddUpdateDocument(Document documentRequest)
        {
            Document dbVersion = documentRepository.Find(documentRequest.DocumentId);

            if (!documentRepository.IsDocumentCodeExist(documentRequest))            
            throw new CaresException(Resources.BusinessPartner.Document.DocumentCodeDuplicationError);

                if (dbVersion != null)
                {
                    UpdateDocumentProperties(documentRequest, dbVersion);
                    documentRepository.Update(dbVersion);
                }
                else
                {
                    dbVersion = new Document();
                    SetDocumentProperties(documentRequest, dbVersion);
                    documentRepository.Add(dbVersion);
                }
                documentRepository.SaveChanges();
                // To Load the proprties
                return documentRepository.GetDocumentWithDetail(dbVersion.DocumentId);
        }

       
        /// <summary>
        /// Load All Documents
        /// </summary>
        public IEnumerable<Document> LoadAll()
        {
            return documentRepository.GetAll();
        }
        #endregion
    }
}
