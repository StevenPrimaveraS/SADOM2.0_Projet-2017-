using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class ForfaitController : Controller
    {
        //Forfait, Reserver

        // GET: Forfait
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Forfait()
        {
            return View();
        }

        //TODO
        public ActionResult Reserver(int id) {
            if(Session["user"] != null) {
                if(Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                    ViewBag.IdForfait = id;
                    return View();
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Reserver(int id, FormCollection collection) {
            try {
                string sDateDebut = collection["dateDebut"];
                string sDateFin = collection["dateFin"];
                List<ForfaitDTO> panierForfait = (List<ForfaitDTO>) Session["panierForfait"];
                List<string> datesForfait = (List<string>) Session["datesForfait"];
                if (panierForfait == null || datesForfait == null) {
                    panierForfait = new List<ForfaitDTO>();
                    datesForfait = new List<string>();
                }
                datesForfait.Add(VADateHandler.ToReservationDates(sDateDebut, sDateFin));
                panierForfait.Add(ApplicationFunctions.ForfaitFacade.Read(id));
                Session["panierForfait"] = panierForfait;
                Session["datesForfait"] = datesForfait;
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
                return View();
            }

            return Redirect("/Home/Index");
        }
        //END TODO

        // GET: Forfait/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                ForfaitDTO forfaitDTO = ApplicationFunctions.ForfaitFacade.Read(id);
                if (forfaitDTO != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null)
                        {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (isAdmin)
                        {
                            ViewBag["forfaitDTO"] = forfaitDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // GET: Forfait/Create
        public ActionResult Create(int IdForfait, int IdChambre, int IdVoiture, int IdSiege, double TarifReduit)
        {
            try
            {
                if (Session["user"] != null)
                {
                    ForfaitDTO forfaitDTO = new ForfaitDTO();
                    forfaitDTO.IdForfait = IdForfait;
                    forfaitDTO.IdChambre = IdChambre;
                    forfaitDTO.IdVoiture = IdVoiture;
                    forfaitDTO.IdSiege = IdSiege;
                    forfaitDTO.TarifReduit = TarifReduit;
                    ApplicationFunctions.ForfaitFacade.Add(forfaitDTO);
                    return View();
                }
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // POST: Forfait/Create
        [HttpPost]
        public ActionResult Create(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Add(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Edit/5
        public ActionResult Edit(int IdForfait, int IdChambre, int IdVoiture, int IdSiege, double TarifReduit)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        if (Session["admin"] != null)
                        {
                            bool idAdmin = (bool)Session["admin"];
                            if (idAdmin)
                            {
                                ForfaitDTO newForfaitDTO = new ForfaitDTO();
                                newForfaitDTO.IdForfait = IdForfait;
                                newForfaitDTO.IdChambre = IdChambre;
                                newForfaitDTO.IdVoiture = IdVoiture;
                                newForfaitDTO.IdSiege = IdSiege;
                                newForfaitDTO.TarifReduit = TarifReduit;
                                ApplicationFunctions.ForfaitFacade.Update(newForfaitDTO);
                                return View();
                            }
                        }
                    }
                }
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // POST: Forfait/Edit/5
        [HttpPost]
        public ActionResult Edit(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Update(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forfait/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ForfaitDTO forfaitDTO = ApplicationFunctions.ForfaitFacade.Read(id);
                if (Session["user"] != null && forfaitDTO != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null)
                        {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (isAdmin)
                        {
                            ApplicationFunctions.ForfaitFacade.Delete(forfaitDTO);
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: Forfait/Delete/5
        [HttpPost]
        public ActionResult Delete(ForfaitDTO forfaitDTO, FormCollection formCollection)
        {
            try
            {
                ApplicationFunctions.ForfaitFacade.Delete(forfaitDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}