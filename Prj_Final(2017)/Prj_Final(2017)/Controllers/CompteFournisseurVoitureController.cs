using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class CompteFournisseurVoitureController : Controller
    {
        // GET: CompteFournisseurVoiture
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return ApplicationFunctions.CompteFournisseurVoitureFacade.Add();
        }
        public ActionResult Read()
        {
            return ApplicationFunctions.CompteFournisseurVoitureFacade.Read();
        }
        public ActionResult Update()
        {
            return ApplicationFunctions.CompteFournisseurVoitureFacade.Update();
        }
        public ActionResult Delete()
        {
            return ApplicationFunctions.CompteFournisseurVoitureFacade.Delete();
        }
    }
}