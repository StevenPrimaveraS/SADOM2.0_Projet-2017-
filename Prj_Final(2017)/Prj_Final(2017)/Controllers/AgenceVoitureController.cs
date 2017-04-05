using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class AgenceVoitureController : Controller
    {
        // GET: AgenceVoiture
        public ActionResult Index()
        {
            return View();
        }
        // GET: AgenceVoiture/Details/5
        public ActionResult Details(AgenceVoitureDTO agenceVoitureDTO)
        {
            ApplicationFunctions.AgenceVoitureFacade.Read(agenceVoitureDTO.IdAgenceVoiture);
            return View();
        }

        // GET: AgenceVoiture/Create
        public ActionResult Create(AgenceVoitureDTO agenceVoitureDTO)
        {
            ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, AgenceVoitureDTO agenceVoitureDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgenceVoiture/Edit/5
        public ActionResult Edit(AgenceVoitureDTO agenceVoitureDTO)
        {
            ApplicationFunctions.AgenceVoitureFacade.Update(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Edit/5
        [HttpPost]
        public ActionResult Edit(AgenceVoitureDTO agenceVoitureDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.AgenceVoitureFacade.Update(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AgenceVoiture()
        {
            return View();
        }
        // GET: AgenceVoiture/Delete/5
        public ActionResult Delete(AgenceVoitureDTO agenceVoitureDTO)
        {
            ApplicationFunctions.AgenceVoitureFacade.Delete(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Delete/5
        [HttpPost]
        public ActionResult Delete(AgenceVoitureDTO agenceVoitureDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.AgenceVoitureFacade.Delete(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}