using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class PanierController : Controller
    {

        //protected override void OnActionExecuting(ActionExecutingContext filterContext) {
        //    if (Session["user"] != null) {
        //        base.OnActionExecuting(filterContext);
        //    }
        //    else {
        //        filterContext.Result = new RedirectResult("~/Account/Login");
        //    }
        //}

        // GET: Panier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Panier()
        {
            return View();
        }

        public ActionResult Acheter() {
            return View();
        }
        [HttpPost]
        public ActionResult Acheter(FormCollection collection) {
            try {
                List<ChambreDTO> panierChambre = (List<ChambreDTO>)Session["panierChambre"];
                List<SiegeDTO> panierSiege = (List<SiegeDTO>)Session["panierSiege"];
                List<VoitureDTO> panierVoiture = (List<VoitureDTO>)Session["panierVoiture"];
                List<ForfaitDTO> panierForfait = (List<ForfaitDTO>)Session["panierForfait"];
                List<string> datesChambre = (List<string>)Session["datesChambre"];
                List<string> datesSiege = (List<string>)Session["datesSiege"];
                List<string> datesVoiture = (List<string>)Session["datesVoiture"];
                List<string> datesForfait = (List<string>)Session["datesForfait"];
                if (panierChambre == null || datesChambre == null) {
                    panierChambre = new List<ChambreDTO>();
                    datesChambre = new List<string>();
                }
                if (panierSiege == null || datesSiege == null) {
                    panierSiege = new List<SiegeDTO>();
                    datesSiege = new List<string>();
                }
                if (panierVoiture == null || datesVoiture == null) {
                    panierVoiture = new List<VoitureDTO>();
                    datesVoiture = new List<string>();
                }
                if (panierForfait == null || datesForfait == null) {
                    panierForfait = new List<ForfaitDTO>();
                    datesForfait = new List<string>();
                }
                //
                if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                    CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                    //reservations chambre
                    List<ReservationChambreDTO> listeReservationsChambre = new List<ReservationChambreDTO>();
                    ReservationChambreDTO reservationChambreDTO = null;
                    for (int i = 0; i < panierChambre.Count; i++) {
                        reservationChambreDTO = new ReservationChambreDTO();
                        reservationChambreDTO.IdParticulier = user.IdParticulier;
                        reservationChambreDTO.IdChambre = panierChambre[i].IdChambre;
                        reservationChambreDTO.DateReservation = VADateHandler.getReservationDates(datesChambre[i])[0];
                        reservationChambreDTO.DateFinReservation = VADateHandler.getReservationDates(datesChambre[i])[1];
                        listeReservationsChambre.Add(reservationChambreDTO);
                    }
                    //Session["reservationsChambre"] = reservationsChambre;
                    //reservations siege
                    List<ReservationSiegeDTO> listeReservationsSiege = new List<ReservationSiegeDTO>();
                    ReservationSiegeDTO reservationSiegeDTO = null;
                    for (int i = 0; i < panierSiege.Count; i++) {
                        reservationSiegeDTO = new ReservationSiegeDTO();
                        reservationSiegeDTO.IdParticulier = user.IdParticulier;
                        reservationSiegeDTO.IdSiege = panierSiege[i].IdSiege;
                        reservationSiegeDTO.DateReservation = VADateHandler.getReservationDates(datesSiege[i])[0];
                        reservationSiegeDTO.DateFinReservation = VADateHandler.getReservationDates(datesSiege[i])[1];
                        listeReservationsSiege.Add(reservationSiegeDTO);
                    }
                    //Session["reservationsSiege"] = reservationsSiege;
                    //reservations voiture
                    List<ReservationVoitureDTO> listeReservationsVoiture = new List<ReservationVoitureDTO>();
                    ReservationVoitureDTO reservationVoitureDTO = null;
                    for (int i = 0; i < panierVoiture.Count; i++) {
                        reservationVoitureDTO = new ReservationVoitureDTO();
                        reservationVoitureDTO.IdParticulier = user.IdParticulier;
                        reservationVoitureDTO.IdVoiture = panierVoiture[i].IdVoiture;
                        reservationVoitureDTO.DateReservation = VADateHandler.getReservationDates(datesVoiture[i])[0];
                        reservationVoitureDTO.DateFinReservation = VADateHandler.getReservationDates(datesVoiture[i])[1];
                        listeReservationsVoiture.Add(reservationVoitureDTO);
                    }
                    //Session["reservationsVoiture"] = reservationsVoiture;
                    //reservations forfait
                    List<ReservationForfaitDTO> listeReservationsForfait = new List<ReservationForfaitDTO>();
                    ReservationForfaitDTO reservationForfaitDTO = null;
                    for (int i = 0; i < panierForfait.Count; i++) {
                        reservationForfaitDTO = new ReservationForfaitDTO();
                        reservationForfaitDTO.IdParticulier = user.IdParticulier;
                        reservationForfaitDTO.IdForfait = panierForfait[i].IdForfait;
                        reservationForfaitDTO.DateReservation = VADateHandler.getReservationDates(datesForfait[i])[0];
                        reservationForfaitDTO.DateFinReservation = VADateHandler.getReservationDates(datesForfait[i])[1];
                        listeReservationsForfait.Add(reservationForfaitDTO);
                    }
                    //Session["reservationsForfait"] = reservationsForfait;
                    //Ajout de toutes les Reservations
                    foreach(ReservationChambreDTO reservationChambre in listeReservationsChambre) {
                        ApplicationFunctions.ReservationChambreFacade.Add(reservationChambre);
                    }
                    foreach (ReservationSiegeDTO reservationSiege in listeReservationsSiege) {
                        ApplicationFunctions.ReservationSiegeFacade.Add(reservationSiege);
                    }
                    foreach (ReservationVoitureDTO reservationVoiture in listeReservationsVoiture) {
                        ApplicationFunctions.ReservationVoitureFacade.Add(reservationVoiture);
                    }
                    foreach (ReservationForfaitDTO reservationForfait in listeReservationsForfait) {
                        ApplicationFunctions.ReservationForfaitFacade.Add(reservationForfait);
                    }
                    Session["panierChambre"] = null;
                    Session["panierSiege"] = null;
                    Session["panierVoiture"] = null;
                    Session["panierForfait"] = null;
                    Session["datesChambre"] = null;
                    Session["datesSiege"] = null;
                    Session["datesVoiture"] = null;
                    Session["datesForfait"] = null;
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Supprimer(int id)
        {
            List<ChambreDTO> panierChambre = (List<ChambreDTO>) Session["panierChambre"];
            List<SiegeDTO> panierSiege = (List<SiegeDTO>) Session["panierSiege"];
            List<VoitureDTO> panierVoiture = (List<VoitureDTO>) Session["panierVoiture"];
            List<ForfaitDTO> panierForfait = (List<ForfaitDTO>) Session["panierForfait"];
            List<string> datesChambre = (List<string>) Session["datesChambre"];
            List<string> datesSiege = (List<string>) Session["datesSiege"];
            List<string> datesVoiture = (List<string>) Session["datesVoiture"];
            List<string> datesForfait = (List<string>) Session["datesForfait"];
            if (panierChambre == null || datesChambre == null) {
                panierChambre = new List<ChambreDTO>();
                datesChambre = new List<string>();
            }
            if (panierSiege == null || datesSiege == null) {
                panierSiege = new List<SiegeDTO>();
                datesSiege = new List<string>();
            }
            if (panierVoiture == null || datesVoiture == null) {
                panierVoiture = new List<VoitureDTO>();
                datesVoiture = new List<string>();
            }
            if (panierForfait == null || datesForfait == null) {
                panierForfait = new List<ForfaitDTO>();
                datesForfait = new List<string>();
            }
            //
            int iterator = id-1;
            bool trouve = false;
            for (int i = 0; i < panierChambre.Count && !trouve; i++) {
                if(iterator == 0) {
                    panierChambre.RemoveAt(i);
                    datesChambre.RemoveAt(i);
                    trouve = true;
                    break;
                }
                iterator--;
            }
            for (int i = 0; i < panierSiege.Count && !trouve; i++) {
                if (iterator == 0) {
                    panierSiege.RemoveAt(i);
                    datesSiege.RemoveAt(i);
                    trouve = true;
                    break;
                }
                iterator--;
            }
            for (int i = 0; i < panierVoiture.Count && !trouve; i++) {
                if (iterator == 0) {
                    panierVoiture.RemoveAt(i);
                    datesVoiture.RemoveAt(i);
                    trouve = true;
                    break;
                }
                iterator--;
            }
            for (int i = 0; i < panierForfait.Count && !trouve; i++) {
                if (iterator == 0) {
                    panierForfait.RemoveAt(i);
                    datesForfait.RemoveAt(i);
                    trouve = true;
                    break;
                }
                iterator--;
            }

            /*try
            {
                PanierDTO panierDTO = new PanierDTO();
                PanierDAO panierDAO = new PanierDAO();
                panierDTO = panierDAO.Read(idItem);
                panierDAO.Delete(panierDTO);
                return RedirectToAction("Panier");
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }*/
            return Redirect("/Panier/Panier");
        }
    }
}