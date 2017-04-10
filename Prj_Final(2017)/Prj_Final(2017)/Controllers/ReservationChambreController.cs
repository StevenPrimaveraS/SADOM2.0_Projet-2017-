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
            if(Session["user"] != null) { 
                base.OnActionExecuting(filterContext);
            }
            else {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }

        // GET: ReservationChambre
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationChambre/Details/5
        public ActionResult Details(int id) {
            try {
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
            }
            //Redirection sinon
            //return RedirectToAction("Index");
            return View();
        }

        // GET: ReservationChambre/Create
        public ActionResult Create() {
            if(Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                CompteParticulierDTO user = (CompteParticulierDTO) Session["user"];
                if (Session["panierChambre"] != null) {
                    List<ChambreDTO> panierChambre = (List<ChambreDTO>) Session["panierChambre"];
                    foreach (ChambreDTO chambreDTO in panierChambre) {
                        ReservationChambreDTO reservationChambreDTO = new ReservationChambreDTO();
                        reservationChambreDTO.IdParticulier = user.IdParticulier;
                        reservationChambreDTO.IdChambre = chambreDTO.IdChambre;
                        //TODO
                        //ApplicationFunctions.ReservationChambreFacade.Add();
                    }
                }
            }
            return Redirect("/");
        }

        // POST: ReservationChambre/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                string sDateDebut = collection["txtDateDebut"];
                string sDateFin = collection["txtDateFin"];
                int idParticulier = int.Parse(collection["idParticulier"]);
                int idChambre = int.Parse(collection["chambre"]);
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

                if (dateDebut >= DateTime.Today && dateFin >= DateTime.Today) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO) Session["user"];
                        ReservationChambreDTO reservationChambreDTO = new ReservationChambreDTO();
                        reservationChambreDTO.IdParticulier = user.IdParticulier;
                        reservationChambreDTO.IdChambre = idChambre;
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

        // GET: ReservationChambre/Edit/5
        public ActionResult Edit(int id) {
            if(Session["admin"] != null) {
                bool isAdmin = (bool) Session["admin"];
                if (isAdmin) {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        // POST: ReservationChambre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                string sDateDebut = collection["txtDateDebut"];
                string sDateFin = collection["txtDateFin"];
                int idParticulier = int.Parse(collection["idParticulier"]);
                int idChambre = int.Parse(collection["chambre"]);
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

                if (dateDebut >= DateTime.Today && dateFin >= DateTime.Today) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO) Session["user"];
                        if (Session["admin"] != null) {
                            bool idAdmin = (bool) Session["admin"];
                            if (idAdmin) {
                                ReservationChambreDTO newReservationChambreDTO = new ReservationChambreDTO();
                                newReservationChambreDTO.IdReservationChambre = id;
                                newReservationChambreDTO.IdParticulier = idParticulier;
                                newReservationChambreDTO.IdChambre = idChambre;
                                newReservationChambreDTO.DateReservation = dateDebut;
                                newReservationChambreDTO.DateFinReservation = dateFin;
                                ApplicationFunctions.ReservationChambreFacade.Update(newReservationChambreDTO);
                                
                                return RedirectToAction("Index");
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
            //recommencer sinon
            return View();
        }

        // GET: ReservationChambre/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationChambreDTO reservationChambreDTO = ApplicationFunctions.ReservationChambreFacade.Read(id);
                if (reservationChambreDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO) Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationChambreDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationChambreFacade.Delete(reservationChambreDTO);

                            return RedirectToAction("Index");
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
