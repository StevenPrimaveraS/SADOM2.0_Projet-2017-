using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class VolController : Controller
    {
        // GET: Vol
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vol() {
            return View();
        }
        // GET: Vol/Details/5
        public ActionResult Details(VolDTO volDTO)
        {
            ApplicationFunctions.VolFacade.Read(volDTO.IdVol);
            return View();
        }

        // GET: Vol/Create
        public ActionResult Create(VolDTO volDTO)
        {
            ApplicationFunctions.VolFacade.Add(volDTO);
            return View();
        }

        // POST: Vol/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, VolDTO volDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.VolFacade.Add(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vol/Edit/5
        public ActionResult Edit(VolDTO volDTO)
        {
            ApplicationFunctions.VolFacade.Update(volDTO);
            return View();
        }

        // POST: Vol/Edit/5
        [HttpPost]
        public ActionResult Edit(VolDTO volDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.VolFacade.Update(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vol/Delete/5
        public ActionResult Delete(VolDTO volDTO)
        {
            ApplicationFunctions.VolFacade.Delete(volDTO);
            return View();
        }

        // POST: Vol/Delete/5
        [HttpPost]
        public ActionResult Delete(VolDTO volDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.VolFacade.Delete(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}