using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    public class BookingMainController : ApiController
    {
        #region Private
        private readonly IBookingMainService bookingMainService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingMainController(IBookingMainService bookingMainService)
        {
            if (bookingMainService == null)
            {
                throw new ArgumentNullException("bookingMainService");
            }

            this.bookingMainService = bookingMainService;
        }
        #endregion

        #region Public
        // GET api/<controller>
        public Models.BookingMainSearchResponse Get([FromUri] BookingMainSearchRequest request)
        {
            return bookingMainService.LoadMainBookings((request)).CreateFrom();
        }

        #endregion
    }
}