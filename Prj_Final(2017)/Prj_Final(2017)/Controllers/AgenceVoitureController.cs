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
    public class AgenceVoitureController : Controller
    {

        //Aucune vue n'existe pour ce contrôleur

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: AgenceVoiture
        public ActionResult Index()
        {
            return View();
        }
        // GET: AgenceVoiture/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                AgenceVoitureDTO agenceVoitureDTO = ApplicationFunctions.AgenceVoitureFacade.Read(id);
                if (agenceVoitureDTO != null)
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
                            ViewBag["agenceVoiture"] = agenceVoitureDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.AgenceVoitureFacade.Read(agenceVoitureDTO.IdAgenceVoiture);
            return View();
        }

        // GET: AgenceVoiture/Create
        public ActionResult Create(int idAgenceVoiture, String nom, String telephone, String adresse, String ville, String aeroport)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        AgenceVoitureDTO agenceVoitureDTO= new AgenceVoitureDTO();
                        agenceVoitureDTO.IdAgenceVoiture = idAgenceVoiture;
                        agenceVoitureDTO.Nom = nom;
                        agenceVoitureDTO.Telephone = telephone;
                        agenceVoitureDTO.Adresse = adresse;
                        agenceVoitureDTO.Ville = ville;
                        agenceVoitureDTO.Aeroport = aeroport;
                        ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);
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
            //ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, AgenceVoitureDTO agenceVoitureDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgenceVoiture/Edit/5
        public ActionResult Edit(int idAgenceVoiture, String nom, String telephone, String adresse, String ville, String aeroport)
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
                                AgenceVoitureDTO agenceVoitureDTO = new AgenceVoitureDTO();
                                agenceVoitureDTO.IdAgenceVoiture = idAgenceVoiture;
                                agenceVoitureDTO.Nom = nom;
                                agenceVoitureDTO.Telephone = telephone;
                                agenceVoitureDTO.Adresse = adresse;
                                agenceVoitureDTO.Ville = ville;
                                agenceVoitureDTO.Aeroport = aeroport;

                                ApplicationFunctions.AgenceVoitureFacade.Update(agenceVoitureDTO);
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
            //ApplicationFunctions.AgenceVoitureFacade.Update(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Edit/5
        [HttpPost]
        public ActionResult Edit(AgenceVoitureDTO agenceVoitureDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.AgenceVoitureFacade.Update(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AgenceVoiture()
        {
            return View();
        }
        // GET: AgenceVoiture/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                AgenceVoitureDTO agenceVoitureDTO = ApplicationFunctions.AgenceVoitureFacade.Read(id);
                if (Session["user"] != null && agenceVoitureDTO != null)
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
                            ApplicationFunctions.AgenceVoitureFacade.Delete(agenceVoitureDTO);
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.AgenceVoitureFacade.Delete(agenceVoitureDTO);
            return View();
        }

        // POST: AgenceVoiture/Delete/5
        [HttpPost]
        public ActionResult Delete(AgenceVoitureDTO agenceVoitureDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.AgenceVoitureFacade.Delete(agenceVoitureDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}