using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Document Base Controller
    /// </summary>
    public class DocumentBaseController : ApiController
    {
        #region Private
        private readonly IDocumentService documentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentBaseController(IDocumentService documentService)
        {
            if (documentService == null)
            {
                throw new ArgumentNullException("documentService");
            }
            this.documentService = documentService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Document Base Data
        /// </summary>
        public Models.DocumentBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return documentService.LoadDocumentBaseData().CreateFrom();
        }
        #endregion
    }
}