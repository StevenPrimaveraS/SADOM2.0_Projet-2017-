using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class SiegeController : Controller
    {
        // GET: Siege
        public ActionResult Index()
        {
            return View();
        }
        // GET: Siege/Details/5
        public ActionResult Details(SiegeDTO siegeDTO)
        {
            ApplicationFunctions.SiegeFacade.Read(siegeDTO.IdSiege);
            return View();
        }

        // GET: Siege/Create
        public ActionResult Create(SiegeDTO siegeDTO)
        {
            ApplicationFunctions.SiegeFacade.Add(siegeDTO);
            return View();
        }

        // POST: Siege/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,SiegeDTO siegeDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.SiegeFacade.Add(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Siege/Edit/5
        public ActionResult Edit(SiegeDTO siegeDTO)
        {
            ApplicationFunctions.SiegeFacade.Update(siegeDTO);
            return View();
        }

        // POST: Siege/Edit/5
        [HttpPost]
        public ActionResult Edit(SiegeDTO siegeDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.SiegeFacade.Update(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Siege()
        {
            return View();
        }
        // GET: Siege/Delete/5
        public ActionResult Delete(SiegeDTO siegeDTO)
        {
            ApplicationFunctions.SiegeFacade.Update(siegeDTO);
            return View();
        }

        // POST: Siege/Delete/5
        [HttpPost]
        public ActionResult Delete(SiegeDTO siegeDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.SiegeFacade.Update(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}