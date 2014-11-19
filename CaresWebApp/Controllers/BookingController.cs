using System;
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

                    BookingViewModel booking = new BookingViewModel()
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
              //  GetAvailableInsurancesRatesResults
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
                BookingViewModel bookingView = new BookingViewModel();
                bookingView.HireGroupDetailId = Convert.ToInt64(collection["HireGroupDetailId"]);
                bookingView.OperationWorkPlaceId = Convert.ToInt64(collection["OperationWorkPlaceId"]);
                bookingView.OperationWorkPlaceCode = Convert.ToString(collection["OperationWorkPlaceCode"]);
                bookingView.StartDt = Convert.ToDateTime(collection["StartDt"]);
                bookingView.EndDt = Convert.ToDateTime(collection["EndDt"]);
                TempData["Booking"] = bookingView;
                return RedirectToAction("Services");

            }
            //hire group get
            BookingViewModel bookingViewModel = TempData["Booking"] as BookingViewModel;
            GetHireGroupRequest hireGroupRequest = new GetHireGroupRequest();
            if (bookingViewModel != null)
            {
                hireGroupRequest.StartDateTime = bookingViewModel.StartDt;
                hireGroupRequest.EndDateTime = bookingViewModel.EndDt;
                hireGroupRequest.OutLocationId = bookingViewModel.OperationWorkPlaceId;
                hireGroupRequest.ReturnLocationId = bookingViewModel.OperationWorkPlaceId;
                hireGroupRequest.DomainKey = 1;
            }
            var result = webApiService.GetHireGroupList(hireGroupRequest).AvailableHireGroups.Select(x => x.CreateFrom());
            ViewBag.BookingVM = TempData["Booking"] as BookingViewModel;

            return View(result.ToList());
        }

        /// <summary>
        ///  GET: Services
        /// </summary>
        /// <returns></returns>
        public ActionResult Services(WebApiRequest request)
        {
            try
            {
                if (request.TarrifTypeCode != null)
                {
                    var insurancesViewModel = new InsurancesViewModel
                    {
                        TarrifTypeCode = request.TarrifTypeCode,
                        DomainKey = request.DomainKey,
                        StartDateTime = request.StartDateTime
                    };
                    TempData["Insurances"] = insurancesViewModel;
                    return RedirectToAction("HireGroup");
                }
                ViewBag.AvailableInsurancesRates = webApiService.GetAvailableInsurancesRates(request);
                ViewBag.AdditionalDriverRates=webApiService.GetAdditionalDriverRates(request);
                ViewBag.AvailableChauffersRates= webApiService.GetAvailableChauffersRates(request);
                return View();
            }
            catch (Exception exp)
            {
                string a = exp.Message;
                throw;
            }
        }

        /// <summary>
        /// GET: Customer Info.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult CustomerInfo(ServicesViewModel request)
        {
            BookingViewModel bookingView = new BookingViewModel();
            bookingView.HireGroupDetailId = Convert.ToInt64(Request.Form["HireGroupDetailId"]);
            bookingView.OperationWorkPlaceId = Convert.ToInt64(Request.Form["OperationWorkPlaceId"]);
            bookingView.OperationWorkPlaceCode = Convert.ToString(Request.Form["OperationWorkPlaceCode"]);
            bookingView.StartDt = Convert.ToDateTime(Request.Form["StartDt"]);
            bookingView.EndDt = Convert.ToDateTime(Request.Form["EndDt"]);
            ViewBag.BookingVM = bookingView;
            return View();
        }

        /// <summary>
        /// Autocomplete 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [WebMethod]
        [HttpPost]
        public JsonResult AutoCompleteLocation(string location)
        {
            //var result = (from r in cares.OperationsWorkplaces
            //              where r.LocationName.ToLower().Contains(location.ToLower())
            //              select new { r.OperationsWorkplaceID, r.LocationName }).Distinct().ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);
            return null; //TODO: Ali Commected as no entities file now in the webapp
        }
    } 
}
