using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class ChambreController : Controller
    {
        // GET: Chambre
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chambre()
        {
            return View();
        }

        // GET: Chambre/Details/5
        public ActionResult Details(ChambreDTO chambreDTO)
        {
            ApplicationFunctions.ChambreFacade.Read(chambreDTO.IdChambre);
            return View();
        }

        // GET: Chambre/Create
        public ActionResult Create(ChambreDTO chambreDTO)
        {
            ApplicationFunctions.ChambreFacade.Add(chambreDTO);
            return View();
        }

        // POST: Chambre/Create
        [HttpPost]
        public ActionResult Create(ChambreDTO chambreDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ChambreFacade.Add(chambreDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chambre/Edit/5
        public ActionResult Edit(ChambreDTO chambreDTO)
        {
            ApplicationFunctions.ChambreFacade.Update(chambreDTO);
            return View();
        }

        // POST: Chambre/Edit/5
        [HttpPost]
        public ActionResult Edit(ChambreDTO chambreDTO, FormCollection formcollection)
        {
            try
            {
                ApplicationFunctions.ChambreFacade.Update(chambreDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chambre/Delete/5
        public ActionResult Delete(ChambreDTO chambreDTO)
        {
            ApplicationFunctions.ChambreFacade.Delete(chambreDTO);
            return View();
        }

        // POST: Chambre/Delete/5
        [HttpPost]
        public ActionResult Delete(ChambreDTO chambreDTO, FormCollection formcollection)
        {
            try
            {
                ApplicationFunctions.ChambreFacade.Delete(chambreDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}