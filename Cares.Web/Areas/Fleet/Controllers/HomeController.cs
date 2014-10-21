using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Cares.Interfaces.IServices;
using Cares.Web.Models;

namespace Cares.Web.Areas.Fleet.Controllers
{
    public class HomeController : Controller
    {

        #region Private
        private readonly IVehicleService vehicleService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController(IVehicleService vehicleService)
        {
            if (vehicleService == null)
            {
                throw new ArgumentNullException("vehicleService");
            }

            this.vehicleService = vehicleService;


        }
        #endregion

        //
        // GET: /FleetPool/Home/
        public ActionResult Index()
        {
            return View();
        }
       
        //
        // GET: /HireGroup/Home/
        public ActionResult HireGroup()
        {
            return View();
        }

        // GET: /Vehicle/Home/
        public ActionResult Vehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Vehicle(HttpPostedFileBase file, long vehicleId)
        {

            
            if (file != null && file.InputStream != null)
            {
              
                // Copy the file
                using (MemoryStream stream = new MemoryStream())
                {
                   // MasterSite masterSite = new MasterSite();
                    file.InputStream.CopyTo(stream);
                    //masterSite.MLogo = stream.ToArray();
                    //companyProfileSaveOperation.Execute(site, masterSite);
                    vehicleService.SaveVehicleImage(stream, vehicleId);
                }
                
            }
            return Json("Uploaded successfully", JsonRequestBehavior.AllowGet);
        }

        public ActionResult VehicleCheckList()
        {
            return View();
        }

        public ActionResult MaintenanceTypeGroup()
        {
            return View();
        }
        public ActionResult MaintenanceType()
        {
            return View();
        }
        public ActionResult InsuranceType()
        {
            return View();
        }
        public ActionResult VehicleMake()
        {
            return View();
        }
        public ActionResult VehicleCategory()
        {
            return View();
        }
        public ActionResult VehicleModel()
        {
            return View();
        }
        public ActionResult VehicleStatus()
        {
            return View();
        }
	}
}