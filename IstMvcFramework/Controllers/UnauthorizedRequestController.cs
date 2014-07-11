using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IstMvcFramework.Controllers
{
    public class UnauthorizedRequestController : Controller
    {
        //
        // GET: /UnauthorizedRequest/
        public ActionResult Index()
        {
            return View();
        }
	}
}