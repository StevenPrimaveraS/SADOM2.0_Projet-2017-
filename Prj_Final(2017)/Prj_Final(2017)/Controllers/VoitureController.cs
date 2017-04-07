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
    public class VoitureController : Controller
    {
        // GET: Voiture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Voiture()
        {
            return View();
        }

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
    }
}