﻿using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers {
    public class ReservationSiegeController : Controller {

        //Aucune sert

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: ReservationSiege
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationSiege/Details/5
        public ActionResult Details(int id) {
            try {
                //Vérification des permissions
                ReservationSiegeDTO reservationSiegeDTO = ApplicationFunctions.ReservationSiegeFacade.Read(id);
                if (reservationSiegeDTO != null && Session["user"] != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationSiegeDTO.IdParticulier || isAdmin) {
                            ViewBag["reservationSiege"] = reservationSiegeDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // GET: ReservationSiege/Create
        public ActionResult Create(int IdSiege, string sDateDebut, string sDateFin) {
            try {
                DateTime dateDebut = DateTime.Today.AddDays(-1);
                DateTime dateFin = DateTime.Today.AddDays(-2); ;
                string[] infos = sDateDebut.Split('/', '-');
                if (infos.Length == 3) {
                    dateDebut = new DateTime(int.Parse(infos[0]), int.Parse(infos[1]), int.Parse(infos[2]));
                }
                infos = sDateFin.Split('/', '-');
                if (infos.Length == 3) {
                    dateFin = new DateTime(int.Parse(infos[0]), int.Parse(infos[1]), int.Parse(infos[2]));
                }

                if (Session["user"] != null &&
                    dateDebut >= DateTime.Today && dateFin >= DateTime.Today) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        ReservationSiegeDTO reservationSiegeDTO = new ReservationSiegeDTO();
                        reservationSiegeDTO.IdParticulier = user.IdParticulier;
                        reservationSiegeDTO.IdSiege = IdSiege;
                        reservationSiegeDTO.DateReservation = dateDebut;
                        reservationSiegeDTO.DateFinReservation = dateFin;
                        ApplicationFunctions.ReservationSiegeFacade.Add(reservationSiegeDTO);

                        return View();
                    }

                }
            }
            catch (FormatException e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // POST: ReservationSiege/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: ReservationSiege/Edit/5
        public ActionResult Edit(int id, int idParticulier, int idSiege, string sDateDebut, string sDateFin) {
            //Vérification des permissions
            try {
                DateTime dateDebut = DateTime.Today.AddDays(-1);
                DateTime dateFin = DateTime.Today.AddDays(-2);
                string[] infos = sDateDebut.Split('/', '-');
                if (infos.Length == 3) {
                    dateDebut = new DateTime(int.Parse(infos[0]), int.Parse(infos[1]), int.Parse(infos[2]));
                }
                infos = sDateFin.Split('/', '-');
                if (infos.Length == 3) {
                    dateFin = new DateTime(int.Parse(infos[0]), int.Parse(infos[1]), int.Parse(infos[2]));
                }

                if (Session["user"] != null && dateDebut >= DateTime.Today && dateFin >= DateTime.Today) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        if (Session["admin"] != null) {
                            bool idAdmin = (bool)Session["admin"];
                            if (idAdmin) {
                                ReservationSiegeDTO newReservationSiegeDTO = new ReservationSiegeDTO();
                                newReservationSiegeDTO.IdReservationSiege = id;
                                newReservationSiegeDTO.IdParticulier = idParticulier;
                                newReservationSiegeDTO.IdSiege = idSiege;
                                newReservationSiegeDTO.DateReservation = dateDebut;
                                newReservationSiegeDTO.DateFinReservation = dateFin;
                                ApplicationFunctions.ReservationSiegeFacade.Update(newReservationSiegeDTO);

                                return View();
                            }
                        }
                    }
                }
            }
            catch (FormatException e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // POST: ReservationSiege/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: ReservationSiege/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationSiegeDTO reservationSiegeDTO = ApplicationFunctions.ReservationSiegeFacade.Read(id);
                if (Session["user"] != null && reservationSiegeDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationSiegeDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationSiegeFacade.Delete(reservationSiegeDTO);

                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: ReservationSiege/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
