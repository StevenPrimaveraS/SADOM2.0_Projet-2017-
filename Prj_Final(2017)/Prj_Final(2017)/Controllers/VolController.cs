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
    public class VolController : Controller
    {

        //Vol


        // GET: Vol
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vol() {
            return View();
        }
        // GET: Vol/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                VolDTO volDTO = ApplicationFunctions.VolFacade.Read(id);
                if (volDTO != null)
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
                            ViewBag["Vol"] = volDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.VolFacade.Read(volDTO.IdVol);
            return View();
        }

        // GET: Vol/Create
        public ActionResult Create(int idVol, String aeroportDepart, String aeroportDestination, String villeDepart, String villeDestination, DateTime dateDepart, DateTime dateArrivee,
            int idCompagnieAerienne, String classe, bool isRemboursable, double tarif)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        VolDTO volDTO= new VolDTO();
                        volDTO.IdVol = idVol;
                        volDTO.AeroportDepart = aeroportDepart;
                        volDTO.AeroportDestination = aeroportDestination;
                        volDTO.VilleDepart = villeDepart;
                        volDTO.VilleDestination = villeDestination;
                        volDTO.DateDepart = dateDepart;
                        volDTO.DateArrivee = dateArrivee;
                        volDTO.IdCompagnieAerienne = idCompagnieAerienne;
                        volDTO.Classe = classe;
                        volDTO.IsRemboursable = isRemboursable;
                        volDTO.Tarif = tarif;
                        ApplicationFunctions.VolFacade.Add(volDTO);

                        return View();
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
            //ApplicationFunctions.VolFacade.Add(volDTO);
            return View();
        }

        // POST: Vol/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, VolDTO volDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.VolFacade.Add(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vol/Edit/5
        public ActionResult Edit(int idVol, String aeroportDepart, String aeroportDestination, String villeDepart, String villeDestination, DateTime dateDepart, DateTime dateArrivee,
            int idCompagnieAerienne, String classe, bool isRemboursable, double tarif)
        {
            //Vérification des permissions
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
                                VolDTO volDTO = new VolDTO();
                                volDTO.IdVol = idVol;
                                volDTO.AeroportDepart = aeroportDepart;
                                volDTO.AeroportDestination = aeroportDestination;
                                volDTO.VilleDepart = villeDepart;
                                volDTO.VilleDestination = villeDestination;
                                volDTO.DateDepart = dateDepart;
                                volDTO.DateArrivee = dateArrivee;
                                volDTO.IdCompagnieAerienne = idCompagnieAerienne;
                                volDTO.Classe = classe;
                                volDTO.IsRemboursable = isRemboursable;
                                volDTO.Tarif = tarif;
                                ApplicationFunctions.VolFacade.Update(volDTO);

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
            //ApplicationFunctions.VolFacade.Update(volDTO);
            return View();
        }

        // POST: Vol/Edit/5
        [HttpPost]
        public ActionResult Edit(VolDTO volDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.VolFacade.Update(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vol/Delete/5
        public ActionResult Delete(int id)
        {
            //ApplicationFunctions.VolFacade.Delete(volDTO);
            try
            {
                VolDTO volDTO = ApplicationFunctions.VolFacade.Read(id);
                if (Session["user"] != null && volDTO != null)
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
                            ApplicationFunctions.VolFacade.Delete(volDTO);
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }

        // POST: Vol/Delete/5
        [HttpPost]
        public ActionResult Delete(VolDTO volDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.VolFacade.Delete(volDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}