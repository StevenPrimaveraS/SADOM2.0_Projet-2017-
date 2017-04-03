using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class ReservationForfaitController : Controller
    {
        // GET: ReservationForfait
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationForfait/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationForfait/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationForfait/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationForfait/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationForfait/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationForfait/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationForfait/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
