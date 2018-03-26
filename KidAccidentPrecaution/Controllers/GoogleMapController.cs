using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidAccidentPrecaution.Controllers
{
    public class GoogleMapController : Controller
    {
        // GET: GoogleMap
        public ActionResult Index(int BandId)
        {
            ViewBag.Latitude = "8.524139";
            ViewBag.Longitude = "76.936638";

            return View();
        }
    }
}