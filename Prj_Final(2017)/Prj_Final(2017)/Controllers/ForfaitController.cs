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

        // GET: Forfait/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forfait/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                // TODO: add Insert logic
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Forfait/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            try
            {
                // TODO: add edit logic
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Forfait/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
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