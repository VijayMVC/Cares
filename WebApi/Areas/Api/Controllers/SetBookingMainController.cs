using Cares.Interfaces.IServices;
using Cares.WebApi.ModelMappers;
using Cares.WebApi.Models;
using System;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    public class SetBookingMainController : ApiController
    {
        #region Private

        private IBookingMainService bookingMainService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SetBookingMainController(IBookingMainService bookingMainService)
        {
            if (bookingMainService == null)
            {
                throw new ArgumentNullException("bookingMainService");
            }
            this.bookingMainService = bookingMainService;
        }
        #endregion
        #region Public

        /// <summary>
        /// Set Booking Main Request 
        /// </summary>        
        public bool Post(WebApiSetBookingRequest webApiRequest)
        {
            bookingMainService.AddBookingMainRequest(webApiRequest.InsurancesTypeIndex, webApiRequest.ChauffersIndexInts,
                (webApiRequest.AdditionalDriver).CreateFrom(), webApiRequest.BookingMainInfo.CreateFrom());
            return true;
        }
        #endregion
    }
}