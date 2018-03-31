using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleMapCoordinates;

namespace KidAccidentPrecaution.Controllers
{
    public class GoogleMapController : Controller
    {
        // GET: GoogleMap
        public ActionResult Index(int BandId)
        {
            GetAccidentLocation objGetLocation = new GetAccidentLocation();
            Location objLocation = objGetLocation.Get();
            ViewBag.Latitude = objLocation.Longitude;
            ViewBag.Longitude = objLocation.Latitude;
            return View();
        }
    }
}