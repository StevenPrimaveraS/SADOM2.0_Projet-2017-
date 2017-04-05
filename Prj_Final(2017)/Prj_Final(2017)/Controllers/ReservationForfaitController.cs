using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers {
    public class ReservationForfaitController : Controller {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: ReservationForfait
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationForfait/Details/5
        public ActionResult Details(int id) {
            try {
                //Vérification des permissions
                ReservationForfaitDTO reservationForfaitDTO = ApplicationFunctions.ReservationForfaitFacade.Read(id);
                if (reservationForfaitDTO != null && Session["user"] != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationForfaitDTO.IdParticulier || isAdmin) {
                            ViewBag["reservationForfait"] = reservationForfaitDTO;
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

        // GET: ReservationForfait/Create
        public ActionResult Create(int IdForfait, string sDateDebut, string sDateFin) {
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
                        ReservationForfaitDTO reservationForfaitDTO = new ReservationForfaitDTO();
                        reservationForfaitDTO.IdParticulier = user.IdParticulier;
                        reservationForfaitDTO.IdForfait = IdForfait;
                        reservationForfaitDTO.DateReservation = dateDebut;
                        reservationForfaitDTO.DateFinReservation = dateFin;
                        ApplicationFunctions.ReservationForfaitFacade.Add(reservationForfaitDTO);

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

        // POST: ReservationForfait/Create
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

        // GET: ReservationForfait/Edit/5
        public ActionResult Edit(int id, int idParticulier, int idForfait, string sDateDebut, string sDateFin) {
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
                                ReservationForfaitDTO newReservationForfaitDTO = new ReservationForfaitDTO();
                                newReservationForfaitDTO.IdReservationForfait = id;
                                newReservationForfaitDTO.IdParticulier = idParticulier;
                                newReservationForfaitDTO.IdForfait = idForfait;
                                newReservationForfaitDTO.DateReservation = dateDebut;
                                newReservationForfaitDTO.DateFinReservation = dateFin;
                                ApplicationFunctions.ReservationForfaitFacade.Update(newReservationForfaitDTO);

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

        // POST: ReservationForfait/Edit/5
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

        // GET: ReservationForfait/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationForfaitDTO reservationForfaitDTO = ApplicationFunctions.ReservationForfaitFacade.Read(id);
                if (Session["user"] != null && reservationForfaitDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationForfaitDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationForfaitFacade.Delete(reservationForfaitDTO);

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

        // POST: ReservationForfait/Delete/5
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
