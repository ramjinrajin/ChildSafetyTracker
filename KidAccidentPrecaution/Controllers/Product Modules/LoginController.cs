using KidAccidentPrecaution.Models.Entities.UserEnitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KidAccidentPrecaution.Controllers
{
    public class LoginController : Controller
    {
        UserControl objUserControl = new UserControl();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection objForm)
        {
            bool isChecked = false;
            if (Request.Form["remember"] != null)
            {
                isChecked = true;
            }

            if (UserControl.AuthenticateUser(Request.Form["USer name"].ToString(), Request.Form["password"].ToString()))//Authentication in database
            //if (FormsAuthentication.Authenticate(Request.Form["USer name"].ToString(), Request.Form["password"].ToString()))//Authentication in Web.config
            {
                FormsAuthentication.SetAuthCookie(Request.Form["USer name"].ToString(), isChecked);
                if (Request.QueryString["returnUrl"] != "" && Request.QueryString["returnUrl"] != null)
                {
                    string sdf = Request.QueryString["returnUrl"];
                    return Redirect(Request.QueryString["returnUrl"]);
                }
                FormsAuthentication.RedirectFromLoginPage(Request.Form["USer name"].ToString(), isChecked);
                ViewBag.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                return RedirectToAction("index", "Home");
            }

            else
            {
 
                TempData["AlertMessage"] = "Invalid";
                return RedirectToAction("Index","Login");
            }
             
        }

        [HttpPost]
        public ActionResult Register(FormCollection FrmUserDetails)
        {
            User _user = new User();
            _user.Username = FrmUserDetails["username"];
            _user.Password = FrmUserDetails["confirm-password2"];
            _user.EmailID = FrmUserDetails["email"];
            if (UserControl.UserRegister(_user))
            {
                TempData["AlertMessage"] = "Sucess";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["AlertMessage"] = "Exists";
                return RedirectToAction("Index", "Login");
            }

            
        }

    }
}