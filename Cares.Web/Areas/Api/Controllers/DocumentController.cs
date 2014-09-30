using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Document API Controller
    /// </summary>
    public class DocumentController : ApiController
    {  
        #region Private
        /// <summary>
        /// Document Service 
        /// </summary>
        private readonly IDocumentService documentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Documents
        /// </summary>
        public DocumentSearchRequestResponse Get([FromUri] DocumentSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  documentService.SearchDocument(request).CreateFrom();
        }

        /// <summary>
        /// Delete Document
        /// </summary>
        [ApiException]
        public Boolean Delete(Document request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            documentService.DeleteDocument(request.DocumentId);
            return true;
        }

        /// <summary>
        /// Add/ Update Document
        /// </summary>
        [ApiException]
        public Document Post(Document request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return documentService.AddUpdateDocument(request.CreateFrom()).CreateFrom();
        }
        #endregion
    }
} 