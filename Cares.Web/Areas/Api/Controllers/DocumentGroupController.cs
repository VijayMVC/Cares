using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Document Group Controller
    /// </summary>
    public class DocumentGroupController : ApiController
    {
       #region Private
        private readonly IDocumentGroupService documentGroupService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentGroupController(IDocumentGroupService documentGroupService)
        {
            if (documentGroupService == null)
            {
                throw new ArgumentNullException("documentGroupService");
            }
            this.documentGroupService = documentGroupService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Document Groups
        /// </summary>
        public Models.DocumentGroupSearchRequestResponse Get([FromUri] DocumentGroupSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return documentGroupService.SearchDocumentGroup(request).CreateFrom();
        }

        /// <summary>
        /// Delete Document Group 
        /// </summary>
        [ApiException]
        public Boolean Delete(DocumentGroup documentGroup)
        {
            if (documentGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            documentGroupService.DeleteDocumentGroup(documentGroup.DocumentGroupId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Document Group
        /// </summary>
        [ApiException]
        public DocumentGroup Post(DocumentGroup documentGroup)
        {
            if (documentGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return documentGroupService.SaveDocumentGroup(documentGroup.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}