using JS_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeverCheck(int temp, string scale)
        {
            ViewBag.TempMessage = FeverChecker.CheckTemp(temp, scale);

            return View();
        }




        public ActionResult FeverCheck()
        {
            return View();
        }


    }
}