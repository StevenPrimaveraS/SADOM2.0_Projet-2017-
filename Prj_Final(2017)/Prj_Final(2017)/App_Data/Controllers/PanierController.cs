using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class PanierController : Controller
    {
        // GET: Panier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Panier()
        {
            return View();
        }
    }
}