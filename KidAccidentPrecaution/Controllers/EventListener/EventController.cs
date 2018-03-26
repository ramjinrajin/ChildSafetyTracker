using KidAccidentPrecaution.Models.Email_Notifier;
using KidAccidentPrecaution.Models.Entities.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidAccidentPrecaution.Controllers.EventListener
{
    public class EventController : Controller
    {

        EmailOrganizer ObjEmail;
        public EventController()
        {
            ObjEmail = new EmailOrganizer();
        }
        public ActionResult Index(int bandId)
        {
            Band ObjBand = new Band();
            ObjBand.bandId=bandId;
            ObjBand.Email = new EmailDataSet();

            ObjBand.Email.SubjectLine = "Alert baby kidnapped";

 
      

            ObjBand.Email.Body = "This is a test messgae";
            ObjEmail.Mailer(ObjBand);


            return View();
        }
    }
}