using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAABSnew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your buying and selling property assistant.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact us if you have any questions.";

            return View();
        }
    }
}