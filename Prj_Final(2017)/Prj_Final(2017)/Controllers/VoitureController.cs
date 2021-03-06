﻿using Prj_Final_2017_.DTO;
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
    public class VoitureController : Controller
    {
        //Voiture, Reserver

        // GET: Voiture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Voiture()
        {
            return View();
        }

        //TODO
        public ActionResult Reserver(int id) {
            if (Session["user"] != null) {
                if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                    ViewBag.IdVoiture = id;
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Reserver(int id, FormCollection collection) {
            try {
                string sDateDebut = collection["dateDebut"];
                string sDateFin = collection["dateFin"];
                List<VoitureDTO> panierVoiture = (List<VoitureDTO>) Session["panierVoiture"];
                List<string> datesVoiture = (List<string>) Session["datesVoiture"];
                if (panierVoiture == null || datesVoiture == null) {
                    panierVoiture = new List<VoitureDTO>();
                    datesVoiture = new List<string>();
                }
                datesVoiture.Add(VADateHandler.ToReservationDates(sDateDebut, sDateFin));
                panierVoiture.Add(ApplicationFunctions.VoitureFacade.Read(id));
                Session["panierVoiture"] = panierVoiture;
                Session["datesVoiture"] = datesVoiture;
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
                return View();
            }

            return Redirect("/Home/Index");
        }
        //END TODO

        // GET: Voiture/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                VoitureDTO voitureDTO = ApplicationFunctions.VoitureFacade.Read(id);
                if (voitureDTO != null)
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
                            ViewBag["voitureDTO"] = voitureDTO;
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

        // GET: Voiture/Create
        public ActionResult Create(int IdVoiture, string Type, int IdAgence,
            double Tarif, int NbPassager, string Nom, string Plaque)
        {
            try
            {
                if (Session["user"] != null)
                {
                    VoitureDTO voitureDTO = new VoitureDTO();
                    voitureDTO.IdVoiture = IdVoiture;
                    voitureDTO.Type = Type;
                    voitureDTO.IdAgence = IdAgence;
                    voitureDTO.Tarif = Tarif;
                    voitureDTO.NbPassager = NbPassager;
                    voitureDTO.Nom = Nom;
                    voitureDTO.Plaque = Plaque;
                    ApplicationFunctions.VoitureFacade.Add(voitureDTO);
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

        // POST: Voiture/Create
        [HttpPost]
        public ActionResult Create(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Add(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voiture/Edit/5
        public ActionResult Edit(int IdVoiture, string Type, int IdAgence,
            double Tarif, int NbPassager, string Nom, string Plaque)
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
                                VoitureDTO newVoitureDTO = new VoitureDTO();
                                newVoitureDTO.IdVoiture = IdVoiture;
                                newVoitureDTO.Type = Type;
                                newVoitureDTO.IdAgence = IdAgence;
                                newVoitureDTO.Tarif = Tarif;
                                newVoitureDTO.NbPassager = NbPassager;
                                newVoitureDTO.Nom = Nom;
                                newVoitureDTO.Plaque = Plaque;
                                ApplicationFunctions.VoitureFacade.Update(newVoitureDTO);
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

        // POST: Voiture/Edit/5
        [HttpPost]
        public ActionResult Edit(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Update(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voiture/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VoitureDTO voitureDTO = ApplicationFunctions.VoitureFacade.Read(id);
                if (Session["user"] != null && voitureDTO != null)
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
                            ApplicationFunctions.VoitureFacade.Delete(voitureDTO);
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

        // POST: Voiture/Delete/5
        [HttpPost]
        public ActionResult Delete(VoitureDTO voitureDTO, FormCollection collection)
        {
            try
            {
                ApplicationFunctions.VoitureFacade.Delete(voitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voiture/AjouterPanier/5
        public ActionResult AjouterPanier(int idItem)
        {
            try
            {
                VoitureDTO voitureDTO = new VoitureDTO();
                voitureDTO = ApplicationFunctions.VoitureFacade.Read(idItem);

                PanierDTO panierDTO = new PanierDTO();
                panierDTO.Information = voitureDTO.Nom;
                panierDTO.Prix = voitureDTO.Tarif;
                panierDTO.Quantite = 1;

                PanierDAO panierDAO = new PanierDAO();
                panierDAO.Add(panierDTO);
                return Redirect("/Voiture/Reserver/"+idItem);
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Voiture");
        }
    }
}