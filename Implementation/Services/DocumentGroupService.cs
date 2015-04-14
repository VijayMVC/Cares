using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Document Group Service
    /// </summary>
    public class DocumentGroupService : IDocumentGroupService
    {
        #region Private
        private readonly IDocumentGroupRepository documentGroupRepository;
        private readonly IDocumentRepository documentRepository;
       
        /// <summary>
        /// Set newly created Document Group object Properties in case of adding
        /// </summary>
        private void SetDocumentGroupProperties(DocumentGroup documentGroup, DocumentGroup dbVersion)
        {
            dbVersion.RecLastUpdatedBy=dbVersion.RecCreatedBy = documentGroupRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt= dbVersion.RecCreatedDt = DateTime.Now;
            dbVersion.DocumentGroupCode = documentGroup.DocumentGroupCode;
            dbVersion.DocumentGroupName = documentGroup.DocumentGroupName;
            dbVersion.DocumentGroupDescription = documentGroup.DocumentGroupDescription;
            dbVersion.UserDomainKey = documentGroupRepository.UserDomainKey;
        }

        /// <summary>
        /// update Document Group object Properties in case of updation
        /// </summary>
        protected void UpdateDocumentGroupPropertie(DocumentGroup documentGroup, DocumentGroup dbVersion)
        {
            dbVersion.RecLastUpdatedBy = documentGroupRepository.LoggedInUserIdentity;
            dbVersion.RecLastUpdatedDt = DateTime.Now;
            dbVersion.RowVersion = dbVersion.RowVersion + 1;
            dbVersion.DocumentGroupCode = documentGroup.DocumentGroupCode;
            dbVersion.DocumentGroupName = documentGroup.DocumentGroupName;
            dbVersion.DocumentGroupDescription = documentGroup.DocumentGroupDescription;
            dbVersion.UserDomainKey = documentGroupRepository.UserDomainKey;
        }

        //Validation check for deletion
        private void ValidateBeforeDeletion(long documentGroupId)
        {
            // Assocoation with Document check 
            if (documentRepository.IsDocumentGroupAssocitedWithDocument(documentGroupId))
                throw new CaresException(Resources.BusinessPartner.DocumentGroup.DocumentGroupIsAssociatedWithDocument);
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentGroupService(IDocumentGroupRepository documentGroupRepository,  IDocumentRepository documentRepository)
        {
            this.documentGroupRepository = documentGroupRepository;
            this.documentRepository = documentRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Load all Document Groups
        /// </summary>
        public IEnumerable<DocumentGroup> LoadAll()
        {
            return documentGroupRepository.GetAll();
        }
        /// <summary>
        /// Search Document Group
        /// </summary>
        public DocumentGroupSearchRequestResponse SearchDocumentGroup(DocumentGroupSearchRequest request)
        {
            int rowCount;
            return new DocumentGroupSearchRequestResponse
            {
                DocumentGroups = documentGroupRepository.SearchDocumentGroup(request, out rowCount),
                TotalCount = rowCount
            };
        }

        /// <summary>
        /// Delete Document Group by id
        /// </summary>
        public void DeleteDocumentGroup(long documentGroupId)
        {
            DocumentGroup dbversion = documentGroupRepository.Find((int)documentGroupId);
            ValidateBeforeDeletion(documentGroupId);
            if (dbversion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BusinessPartner.DocumentGroup.DocumentGroupNotFound));
            }
            documentGroupRepository.Delete(dbversion);
            documentGroupRepository.SaveChanges();  
        }

        /// <summary>
        /// Add /Update Document Group
        /// </summary>
        public DocumentGroup SaveDocumentGroup(DocumentGroup documentGroup)
        {
            DocumentGroup dbVersion = documentGroupRepository.Find(documentGroup.DocumentGroupId);

            //Code Duplication Check
            if (documentGroupRepository.DoesDocumentGroupCodeExists(documentGroup))
                throw new CaresException(Resources.BusinessPartner.DocumentGroup.DocumentGroupCodeDuplicationError);
            if (dbVersion != null)
            {
                UpdateDocumentGroupPropertie(documentGroup, dbVersion);
                documentGroupRepository.Update(dbVersion);
            }
            else
            {
                dbVersion = new DocumentGroup();
                SetDocumentGroupProperties(documentGroup, dbVersion);
                documentGroupRepository.Add(dbVersion);
            }
            documentGroupRepository.SaveChanges();
            // To Load the proprties
            return documentGroupRepository.Find(dbVersion.DocumentGroupId);
        }
        #endregion
    }
}