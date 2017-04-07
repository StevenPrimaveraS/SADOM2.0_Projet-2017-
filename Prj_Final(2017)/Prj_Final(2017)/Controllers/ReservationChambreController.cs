using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers {
    public class ReservationChambreController : Controller {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
           // if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            //else
                //filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: ReservationChambre
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationChambre/Details/5
        public ActionResult Details(int id) {
            /*try {
                //Vérification des permissions
                ReservationChambreDTO reservationChambreDTO = ApplicationFunctions.ReservationChambreFacade.Read(id);
                if (reservationChambreDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationChambreDTO.IdParticulier || isAdmin) {
                            ViewBag["reservationChambre"] = reservationChambreDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }*/
            //Redirection sinon
            //return RedirectToAction("Index");
            return View();
        }

        // GET: ReservationChambre/Create
        public ActionResult Create(int IdChambre, string sDateDebut, string sDateFin) {
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
                        ReservationChambreDTO reservationChambreDTO = new ReservationChambreDTO();
                        reservationChambreDTO.IdParticulier = user.IdParticulier;
                        reservationChambreDTO.IdChambre = IdChambre;
                        reservationChambreDTO.DateReservation = dateDebut;
                        reservationChambreDTO.DateFinReservation = dateFin;
                        ApplicationFunctions.ReservationChambreFacade.Add(reservationChambreDTO);

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

        // POST: ReservationChambre/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            string nom = collection["idtxtnom"];
            ApplicationFunctions.CompteFournisseurChambreFacade.Add(new CompteFournisseurChambreDTO());
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: ReservationChambre/Edit/5
        public ActionResult Edit(int id, int idParticulier, int idChambre, string sDateDebut, string sDateFin) {
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
                                ReservationChambreDTO newReservationChambreDTO = new ReservationChambreDTO();
                                newReservationChambreDTO.IdReservationChambre = id;
                                newReservationChambreDTO.IdParticulier = idParticulier;
                                newReservationChambreDTO.IdChambre = idChambre;
                                newReservationChambreDTO.DateReservation = dateDebut;
                                newReservationChambreDTO.DateFinReservation = dateFin;
                                ApplicationFunctions.ReservationChambreFacade.Update(newReservationChambreDTO);

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

        // POST: ReservationChambre/Edit/5
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

        // GET: ReservationChambre/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationChambreDTO reservationChambreDTO = ApplicationFunctions.ReservationChambreFacade.Read(id);
                if (Session["user"] != null && reservationChambreDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationChambreDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationChambreFacade.Delete(reservationChambreDTO);

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

        // POST: ReservationChambre/Delete/5
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
