using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers {
    public class ReservationVoitureController : Controller {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: ReservationVoiture
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationVoiture/Details/5
        public ActionResult Details(int id) {
            try {
                //Vérification des permissions
                ReservationVoitureDTO reservationVoitureDTO = ApplicationFunctions.ReservationVoitureFacade.Read(id);
                if (reservationVoitureDTO != null && Session["user"] != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationVoitureDTO.IdParticulier || isAdmin) {
                            ViewBag["reservationVoiture"] = reservationVoitureDTO;
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

        // GET: ReservationVoiture/Create
        public ActionResult Create(int IdVoiture, string sDateDebut, string sDateFin) {
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
                        ReservationVoitureDTO reservationVoitureDTO = new ReservationVoitureDTO();
                        reservationVoitureDTO.IdParticulier = user.IdParticulier;
                        reservationVoitureDTO.IdVoiture = IdVoiture;
                        reservationVoitureDTO.DateReservation = dateDebut;
                        reservationVoitureDTO.DateFinReservation = dateFin;
                        ApplicationFunctions.ReservationVoitureFacade.Add(reservationVoitureDTO);

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

        // POST: ReservationVoiture/Create
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

        // GET: ReservationVoiture/Edit/5
        public ActionResult Edit(int id, int idParticulier, int idVoiture, string sDateDebut, string sDateFin) {
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
                                ReservationVoitureDTO newReservationVoitureDTO = new ReservationVoitureDTO();
                                newReservationVoitureDTO.IdReservationVoiture = id;
                                newReservationVoitureDTO.IdParticulier = idParticulier;
                                newReservationVoitureDTO.IdVoiture = idVoiture;
                                newReservationVoitureDTO.DateReservation = dateDebut;
                                newReservationVoitureDTO.DateFinReservation = dateFin;
                                ApplicationFunctions.ReservationVoitureFacade.Update(newReservationVoitureDTO);

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

        // POST: ReservationVoiture/Edit/5
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

        // GET: ReservationVoiture/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationVoitureDTO reservationVoitureDTO = ApplicationFunctions.ReservationVoitureFacade.Read(id);
                if (Session["user"] != null && reservationVoitureDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationVoitureDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationVoitureFacade.Delete(reservationVoitureDTO);

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

        // POST: ReservationVoiture/Delete/5
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
