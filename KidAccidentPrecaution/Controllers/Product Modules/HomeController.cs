using KidAccidentPrecaution.Models.BandAdoDotNet;
using KidAccidentPrecaution.Models.Entities.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KidAccidentPrecaution.Controllers
{
    public class HomeController : Controller
    {
       [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            ViewBag.Message = "NIL";
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(FormCollection frm)
        {

            BandDataLayer objBandDataLayer = new BandDataLayer();
            Band objBand = new Band
            {
                BandNo = frm["BandNo"].ToString(),
                BandSLNO = frm["BandSLNO"].ToString(),
                NotificationType = frm["NotificationType"].ToString(),
            };

            var Result = objBandDataLayer.InsertBand(objBand);

            if (Result.Status==BandStatus.Success)
            {
                ViewBag.Message = Result.Message;
                ViewBag.Status = "Success";
            }
            if (Result.Status == BandStatus.Warning)
            {
                ViewBag.Message = Result.Message;
                ViewBag.Status = "Warning";
            }

            if (Result.Status == BandStatus.Error)
            {
                ViewBag.Message = Result.Message;
                ViewBag.Status = "Error";
            }


            return View();
        }

        [HttpGet]
        public ActionResult logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}