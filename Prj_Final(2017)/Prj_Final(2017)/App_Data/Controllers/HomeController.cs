using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "À propos de Voyage Ahuntsic..";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pour nous contacter.";

            return View();
        }
    }
}