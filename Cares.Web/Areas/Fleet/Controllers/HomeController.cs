using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Cares.Interfaces.IServices;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Fleet.Controllers
{
    /// <summary>
    /// Fleet Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "Fleet")]
    public class HomeController : BaseController
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
        [SiteAuthorize(PermissionKey = "FleetPool")]
        public ActionResult Index()
        {
            return View();
        }
       
        //
        // GET: /HireGroup/Home/
        [SiteAuthorize(PermissionKey = "HireGroup")]
        public ActionResult HireGroup()
        {
            return View();
        }

        // GET: /Vehicle/Home/
        [SiteAuthorize(PermissionKey = "Vehicle")]
        public ActionResult VehicleMain()
        {
            return View();
        }

        [HttpPost]
        [SiteAuthorize(PermissionKey = "Vehicle")]
        public ActionResult Vehicle(HttpPostedFileBase file, long vehicleId)
        {

            
            if (file != null && file.InputStream != null)
            {
              
                // Copy the file
                using (MemoryStream stream = new MemoryStream())
                {
                    file.InputStream.CopyTo(stream);
                       vehicleService.SaveVehicleImage(stream, vehicleId);
                }
                
            }
            //return Json("Uploaded successfully", JsonRequestBehavior.AllowGet);
            return null;
        }
        [SiteAuthorize(PermissionKey = "VehicleCheckList")]
        public ActionResult VehicleCheckList()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "MaintenanceTypeGroup")]
        public ActionResult MaintenanceTypeGroup()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "MaintenanceType")]
        public ActionResult MaintenanceType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "InsuranceType")]
        public ActionResult InsuranceType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "VehicleMake")]
        public ActionResult VehicleMake()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "VehicleCategory")]
        public ActionResult VehicleCategory()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "VehicleModel")]
        public ActionResult VehicleModel()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "VehicleStatus")]
        public ActionResult VehicleStatus()
        {
            return View();
        }
	}
}