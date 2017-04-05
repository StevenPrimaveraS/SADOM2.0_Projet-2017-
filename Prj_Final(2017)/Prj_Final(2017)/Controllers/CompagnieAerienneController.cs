using Prj_Final_2017_.Models.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class CompagnieAerienneController : Controller
    {
        // GET: CompagnieAerienne
        public ActionResult Index()
        {
            return View();
        }
        // GET: CompagnieAerienne/Details/5
        public ActionResult Details(CompagnieAerienneDTO compagnieAerienneDTO)
        {
            ApplicationFunctions.CompagnieAerienneFacade.Read(compagnieAerienneDTO.IdCompagnieAerienne);
            return View();
        }

        // GET: CompagnieAerienne/Create
        public ActionResult Create(CompagnieAerienneDTO compagnieAerienneDTO)
        {
            ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, CompagnieAerienneDTO compagnieAerienneDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompagnieAerienne/Edit/5
        public ActionResult Edit(CompagnieAerienneDTO compagnieAerienneDTO)
        {
            ApplicationFunctions.CompagnieAerienneFacade.Update(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Edit/5
        [HttpPost]
        public ActionResult Edit(CompagnieAerienneDTO compagnieAerienneDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.CompagnieAerienneFacade.Update(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CompagnieAerienne()
        {
            return View();
        }
        // GET: CompagnieAerienne/Delete/5
        public ActionResult Delete(CompagnieAerienneDTO compagnieAerienneDTO)
        {
            ApplicationFunctions.CompagnieAerienneFacade.Delete(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Delete/5
        [HttpPost]
        public ActionResult Delete(CompagnieAerienneDTO compagnieAerienneDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.CompagnieAerienneFacade.Delete(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}