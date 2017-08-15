using EasyManager.UI.Models;
using EasyManagerBLL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyManager.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        EasyManagerBL bll = new EasyManagerBL();
        string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        public ActionResult Index()
        {
            var model = new LoginViewModel();
            model.StatsList = bll.GetSimpleStats(UserId);
            //ViewBag.ReturnUrl = returnUrl;
            ViewBag.Home = "class = active";
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}