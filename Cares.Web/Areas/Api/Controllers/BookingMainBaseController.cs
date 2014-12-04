using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    public class BookingMainBaseController : ApiController
    {
         #region Private
        private readonly IBookingMainService bookingMainService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingMainBaseController(IBookingMainService bookingMainService)
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
        public BookingMainBaseResponse Get()
        {
            return bookingMainService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}