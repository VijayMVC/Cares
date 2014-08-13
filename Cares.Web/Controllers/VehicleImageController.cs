using System;
using System.Web.Mvc;
using Cares.Interfaces.IServices;
using Cares.Web.Models;
using Cares.Web.ModelMappers;

namespace Cares.Web.Controllers
{
    public class VehicleImageController : Controller
    {
        #region Private

        private readonly IVehicleService vehicleService;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleImageController(IVehicleService vehicleService)
        {
            if (vehicleService == null)
            {
                throw new ArgumentNullException("vehicleService");
            }
            this.vehicleService = vehicleService;
        }

        #endregion
        #region Actions

        /// <summary>
        /// Index
        /// </summary>
        public ActionResult Index(int id)
        {
            Vehicle vehicle = vehicleService.GetById(id).CreateFrom();
            if (vehicle.Image == null || vehicle.Image.Length == 0)
                return null;

            return new FileContentResult(vehicle.Image, "image/png");
        }
        #endregion
    }
}
