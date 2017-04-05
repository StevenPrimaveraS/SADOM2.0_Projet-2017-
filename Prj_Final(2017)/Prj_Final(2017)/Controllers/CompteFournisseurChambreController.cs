using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class CompteFournisseurChambreController : Controller
    {
        // GET: CompteFournisseurChambre
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return ApplicationFunctions.CompteFournisseurChambreFacade.Add();
        }
        public ActionResult Read()
        {
            return ApplicationFunctions.CompteFournisseurChambreFacade.Read();
        }
        public ActionResult Update()
        {
            return ApplicationFunctions.CompteFournisseurChambreFacade.Update();
        }
        public ActionResult Delete()
        {
            return ApplicationFunctions.CompteFournisseurChambreFacade.Delete();
        }
    }
}