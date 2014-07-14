using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Interfaces.IServices;
using Models.RequestModels;
using Models.ResponseModels;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type Base Api Controller
    /// </summary>
    public class TarrifTypeBaseController : ApiController
    {

        #region Private
         private readonly ITarrifTypeService tarrifTypeService;
        #endregion
        #region Constructors
         /// <summary>
        /// Constructor
        /// </summary>
         public TarrifTypeBaseController(ITarrifTypeService tarrifTypeService)
        {
            if (tarrifTypeService == null)
            {
                throw new ArgumentNullException("tarrifTypeService");    
            }

            this.tarrifTypeService = tarrifTypeService;
        }
        #endregion
        #region Public
          // GET api/<controller>
         public TarrifTypeBaseResponse Get(TarrifTypeRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tarrifTypeService.LoadAllTarrifTypes(request);
        }
        #endregion
       

     
    }
}