using Cares.Interfaces.IServices;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Models.ResponseModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Phone Controller
    /// </summary>
    [Authorize]
    public class PhoneController : ApiController
    {
        #region Private
        private readonly IPhoneService phoneService;
        #endregion
        #region Constructor
        /// <summary>
        /// Phone Constructor
        /// </summary>
        public PhoneController(IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get Phones
        /// </summary>
        public Models.PhonesSearchByWorkLocationIdResponse Get([FromUri] long workLocationId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
         //   return 
            PhonesSearchByWorkLocationIdResponse response = phoneService.GetPhonesByWorklocationId(workLocationId);

            return response.CreateFrom();
            
        }
        #endregion
    }
}