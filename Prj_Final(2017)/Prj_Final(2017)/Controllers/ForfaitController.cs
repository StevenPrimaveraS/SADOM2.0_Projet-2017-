using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class ForfaitController : Controller
    {
        // GET: Forfait
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Forfait()
        {
            return View();
        }

        // GET: Forfait/Details/5
        public ActionResult Details(ForfaitDTO forfaitDTO)
        {
            ApplicationFunctions.ForfaitFacade.Read(forfaitDTO.IdForfait);
            return View();
        }

        // GET: Forfait/Create
        public ActionResult Create(ForfaitDTO forfaitDTO)
        {
            ApplicationFunctions.ForfaitFacade.Add(forfaitDTO);
            return View();
        }

        // POST: Forfait/Create
        [HttpPost]
        public ActionResult Create(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Add(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Edit/5
        public ActionResult Edit(ForfaitDTO forfaitDTO)
        {
            ApplicationFunctions.ForfaitFacade.Update(forfaitDTO);
            return View();
        }

        // POST: Forfait/Edit/5
        [HttpPost]
        public ActionResult Edit(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Update(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Delete/5
        public ActionResult Delete(ForfaitDTO forfaitDTO)
        {
            ApplicationFunctions.ForfaitFacade.Delete(forfaitDTO);
            return View();
        }

        // POST: Forfait/Delete/5
        [HttpPost]
        public ActionResult Delete(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Delete(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}