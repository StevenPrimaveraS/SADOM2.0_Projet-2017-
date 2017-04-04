using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class CompteFournisseurSiegeController : Controller
    {
        // GET: CompteFournisseurSiege
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return ApplicationFunctions.CompteFournisseurSiegeFacade.Add();
        }
        public ActionResult Read()
        {
            return ApplicationFunctions.CompteFournisseurSiegeFacade.Read();
        }
        public ActionResult Update()
        {
            return ApplicationFunctions.CompteFournisseurSiegeFacade.Update();
        }
        public ActionResult Delete()
        {
            return ApplicationFunctions.CompteFournisseurSiegeFacade.Delete();
        }
    }
}