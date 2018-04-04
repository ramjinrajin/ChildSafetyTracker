using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidAccidentPrecaution.Controllers.Product_Modules
{
    public class SubscribeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ViewBag.Message = "congratulations!!! you are successfully subscribed";
            ViewBag.Status = "Success";
            return View();
        }
    }
}