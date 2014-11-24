using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;
using Cares.WebApp.Common;
using Cares.WebApp.Models;
using Cares.WebApp.ModelsMapper;
using Cares.WebApp.ViewModel;
using Cares.WebApp.WebApi;
using Cares.WebApp.WepApiInterface;

namespace Cares.WebApp.Controllers
{
    /// <summary>
    /// Booking Controller
    /// </summary>
    public class BookingController : Controller
    {        
        private IWebApiService webApiService;
        public BookingController()
        {
            this.webApiService = new WebApiService();
        }
        // GET: Booking
        public ActionResult Index(BookingSearchRequest request)
        {
            try
            {
                if (request.OperationWorkPlaceCode != null && request.OperationWorkPlaceId != 0)
                {
                    var booking = new BookingViewModel()
                    {
                        OperationWorkPlaceCode = request.OperationWorkPlaceCode,
                        OperationWorkPlaceId = request.OperationWorkPlaceId,
                        StartDt = request.StartDt,
                        EndDt = request.EndDt
                    };
                    TempData["Booking"] = booking;
                    CompleteBookingData.Booking = booking;
                    return RedirectToAction("HireGroup");
                }
                GetOperationWorkplaceResult results = webApiService.GetOperationWorkplaceList(1);
                ViewBag.OperationWorkPlaces = results;
                return View();
            }
            catch (Exception exp)
            {
                string a = exp.Message;
                throw;
            }
        }

        // GET: Hire Group 
        //[WebMethod]
        //[HttpPost]
        public ActionResult HireGroup(FormCollection collection)
        {
            if (collection["HireGroupDetailId"] != null)
            {
                var bookingView = new BookingViewModel
                {
                    HireGroupDetailId = Convert.ToInt64(collection["HireGroupDetailId"]),
                    OperationWorkPlaceId = Convert.ToInt64(collection["OperationWorkPlaceId"]),
                    OperationWorkPlaceCode = Convert.ToString(collection["OperationWorkPlaceCode"]),
                    StartDt = Convert.ToDateTime(collection["StartDateTime"]),
                    EndDt = Convert.ToDateTime(collection["EndDateTime"]),
                    TariffTypeCode = Convert.ToString(collection["TariffTypeCode"])
                };
                TempData["Booking"] = bookingView;
                return RedirectToAction("Services");

            }
            //hire group get
            var bookingViewModel = TempData["Booking"] as BookingViewModel;
            var hireGroupRequest = new GetHireGroupRequest();
            if (bookingViewModel != null)
            {
                hireGroupRequest.StartDateTime = bookingViewModel.StartDt;
                hireGroupRequest.EndDateTime = bookingViewModel.EndDt;
                hireGroupRequest.OutLocationId = bookingViewModel.OperationWorkPlaceId;
                hireGroupRequest.ReturnLocationId = bookingViewModel.OperationWorkPlaceId;
                hireGroupRequest.DomainKey = 1;
            }
            IEnumerable<HireGroupDetail> hireGroupDetails = webApiService.GetHireGroupList(hireGroupRequest)  .AvailableHireGroups.Select(x => x.CreateFrom());
            ViewBag.BookingVM = TempData["Booking"] as BookingViewModel;
            return View(hireGroupDetails.ToList());
        }

        /// <summary>
        ///  GET: Services
        /// </summary>
        public ActionResult Services(FormCollection collection)
        {
            var bookingViewModel = TempData["Booking"] as BookingViewModel;
            var hireGroupRequest = new WebApiRequest();
            if (bookingViewModel != null)
            {
                hireGroupRequest.StartDateTime = bookingViewModel.StartDt;
                hireGroupRequest.EndDateTime = bookingViewModel.EndDt;
                hireGroupRequest.OutLocationId = bookingViewModel.OperationWorkPlaceId;
                hireGroupRequest.DomainKey = 1;
                hireGroupRequest.TarrifTypeCode = bookingViewModel.TariffTypeCode;
            }
            var availableInsurancesRates = webApiService.GetAvailableInsurancesRates(hireGroupRequest).ApiAvailableInsurances;
            var additionalDriverRates = webApiService.GetAdditionalDriverRates(hireGroupRequest).WebApiAdditionalDriverRates;
            var availableCahuffersRates = webApiService.GetAvailableChauffersRates(hireGroupRequest).ApiAvailableChuffersRates;

            ViewBag.availableInsurancesRates = availableInsurancesRates;
            ViewBag.additionalDriverRates = additionalDriverRates;
            ViewBag.availableCahuffersRates = availableCahuffersRates;

            ViewBag.BookingVM = TempData["Booking"] as BookingViewModel;
            return View();
        }

        /// <summary>
        /// GET: Customer Info.
        /// </summary>
        public ActionResult CustomerInfo(ServicesViewModel request)
        {
            var bookingView = new BookingViewModel
            {
                HireGroupDetailId = Convert.ToInt64(Request.Form["HireGroupDetailId"]),
                OperationWorkPlaceId = Convert.ToInt64(Request.Form["OperationWorkPlaceId"]),
                OperationWorkPlaceCode = Convert.ToString(Request.Form["OperationWorkPlaceCode"]),
                StartDt = Convert.ToDateTime(Request.Form["StartDt"]),
                EndDt = Convert.ToDateTime(Request.Form["EndDt"])
            };
            ViewBag.BookingVM = bookingView;
            return View();
        }

        /// <summary>
        /// Autocomplete 
        /// </summary>
        [WebMethod]
        [HttpPost]
        public JsonResult AutoCompleteLocation(string location)
        {           
            return null; 
        }
    } 
}
