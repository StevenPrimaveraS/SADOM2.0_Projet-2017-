﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class ReservationChambreController : Controller
    {
        // GET: ReservationChambre
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationChambre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationChambre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationChambre/Create
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

        // GET: ReservationChambre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationChambre/Edit/5
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

        // GET: ReservationChambre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationChambre/Delete/5
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