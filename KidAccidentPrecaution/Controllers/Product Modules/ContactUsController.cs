using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidAccidentPrecaution.Controllers.Product_Modules
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ViewBag.Message = "Thank you for the query ,We will contact you shortly";
            ViewBag.Status = "Success";
            return View();
        }
    }
}