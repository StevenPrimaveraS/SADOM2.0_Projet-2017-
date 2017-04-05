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

        // GET: Chambre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chambre/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                // TODO: add insert logic
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chambre/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Chambre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formcollection)
        {
            try
            {
                // TODO: add update logic
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chambre/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Chambre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formcollection)
        {
            try
            {
                // TODO: add delete logic
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}