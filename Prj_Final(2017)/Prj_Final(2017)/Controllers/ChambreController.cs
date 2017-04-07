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
    public class ChambreController : Controller
    {
        // GET: Chambre
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chambre()
        {
            return View();
        }

        // GET: Chambre/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                ChambreDTO chambreDTO = ApplicationFunctions.ChambreFacade.Read(id);
                if (chambreDTO != null)
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
                            ViewBag["chambreDTO"] = chambreDTO;
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

        // GET: Chambre/Create
        public ActionResult Create(int IdChambre, int NumeroChambre, 
            string NomChambre, double Tarif, int MaxPersonne, int Taille, string Description, int IdHotel)
        {
            try
            {
                if (Session["user"] != null)
                {
                    ChambreDTO chambreDTO = new ChambreDTO();
                    chambreDTO.IdChambre = IdChambre;
                    chambreDTO.NumeroChambre = NumeroChambre;
                    chambreDTO.NomChambre = NomChambre;
                    chambreDTO.Tarif = Tarif;
                    chambreDTO.MaxPersonne = MaxPersonne;
                    chambreDTO.Taille = Taille;
                    chambreDTO.Description = Description;
                    chambreDTO.IdHotel = IdHotel;
                    ApplicationFunctions.ChambreFacade.Add(chambreDTO);
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

        // POST: Chambre/Create
        [HttpPost]
        public ActionResult Create(ChambreDTO chambreDTO, FormCollection formCollection)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.ChambreFacade.Add(chambreDTO);
                return RedirectToAction("Index");
            }
            catch (VoyageAhuntsicException e)
            {
                return View();
            }    
        }

        // GET: Chambre/Edit/5
        public ActionResult Edit(int IdChambre, int NumeroChambre,
            string NomChambre, double Tarif, int MaxPersonne, int Taille, string Description, int IdHotel)
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
                                ChambreDTO newChambreDTO = new ChambreDTO();
                                newChambreDTO.IdChambre = IdChambre;
                                newChambreDTO.NumeroChambre = NumeroChambre;
                                newChambreDTO.NomChambre = NomChambre;
                                newChambreDTO.Tarif = Tarif;
                                newChambreDTO.MaxPersonne = MaxPersonne;
                                newChambreDTO.Taille = Taille;
                                newChambreDTO.Description = Description;
                                newChambreDTO.IdHotel = IdHotel;
                                ApplicationFunctions.ChambreFacade.Update(newChambreDTO);
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

        // POST: Chambre/Edit/5
        [HttpPost]
        public ActionResult Edit(ChambreDTO chambreDTO, FormCollection formcollection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.ChambreFacade.Update(chambreDTO);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Chambre/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ChambreDTO chambreDTO = ApplicationFunctions.ChambreFacade.Read(id);
                if (Session["user"] != null && chambreDTO != null)
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
                            ApplicationFunctions.ChambreFacade.Delete(chambreDTO);
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

        // POST: Chambre/Delete/5
        [HttpPost]
        public ActionResult Delete(ChambreDTO chambreDTO, FormCollection formcollection)
        {
            try
            {
                ApplicationFunctions.ChambreFacade.Delete(chambreDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}