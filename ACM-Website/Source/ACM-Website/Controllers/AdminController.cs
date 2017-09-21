using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ACM_Website.Models;

namespace ACM_Website.Controllers
{
    public class AdminController : Controller
    {
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public bool IsInRole(string role)
        {
            return AuthenticationManager.User.IsInRole(role);
        }


        // GET: Admin
        public ActionResult Index()
        {
            //test how to sign somebody out
            AuthenticationManager.SignOut();
            return View();
        }
        public ActionResult Admin()
        {
            //testing how to redirect if user is not in a role
            if (IsInRole("Admin")) 
                return View();
            return RedirectToAction("Index", "Home");
        }
    }
}