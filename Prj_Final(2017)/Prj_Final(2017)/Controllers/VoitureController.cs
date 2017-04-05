using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class VoitureController : Controller
    {
        // GET: Voiture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Voiture()
        {
            return View();
        }

        // GET: Voiture/Details/5
        public ActionResult Details(VoitureDTO voitureDTO)
        {
            ApplicationFunctions.VoitureFacade.Read(voitureDTO.IdVoiture);
            return View();
        }

        // GET: Voiture/Create
        public ActionResult Create(VoitureDTO voitureDTO)
        {
            ApplicationFunctions.VoitureFacade.Add(voitureDTO);
            return View();
        }

        // POST: Voiture/Create
        [HttpPost]
        public ActionResult Create(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Add(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voiture/Edit/5
        public ActionResult Edit(VoitureDTO voitureDTO)
        {
            ApplicationFunctions.VoitureFacade.Update(voitureDTO);
            return View();
        }

        // POST: Voiture/Edit/5
        [HttpPost]
        public ActionResult Edit(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Update(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voiture/Delete/5
        public ActionResult Delete(VoitureDTO voitureDTO)
        {
            ApplicationFunctions.VoitureFacade.Delete(voitureDTO);
            return View();
        }

        // POST: Voiture/Delete/5
        [HttpPost]
        public ActionResult Delete(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Delete(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}