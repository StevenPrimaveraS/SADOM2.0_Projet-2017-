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
    public class CompagnieAerienneController : Controller
    {

        //Aucune vue n'existe pour ce contrôleur

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: CompagnieAerienne
        public ActionResult Index()
        {
            return View();
        }
        // GET: CompagnieAerienne/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                CompagnieAerienneDTO compagnieAerienneDTO= ApplicationFunctions.CompagnieAerienneFacade.Read(id);
                if (compagnieAerienneDTO != null)
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
                            ViewBag["compagnieAerienne"] = compagnieAerienneDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.CompagnieAerienneFacade.Read(compagnieAerienneDTO.IdCompagnieAerienne);
            return View();
        }

        // GET: CompagnieAerienne/Create
        public ActionResult Create(int idCompagnieAerienne, String nom, String telephone, String adresse, String ville)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        CompagnieAerienneDTO compagnieAerienneDTO = new CompagnieAerienneDTO();
                        compagnieAerienneDTO.IdCompagnieAerienne = idCompagnieAerienne;
                        compagnieAerienneDTO.Nom = nom;
                        compagnieAerienneDTO.Telephone = telephone;
                        compagnieAerienneDTO.Adresse = adresse;
                        compagnieAerienneDTO.Ville = ville;
                        ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);
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
            //ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, CompagnieAerienneDTO compagnieAerienneDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompagnieAerienne/Edit/5
        public ActionResult Edit(int idCompagnieAerienne, String nom, String telephone, String adresse, String ville)
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
                                CompagnieAerienneDTO compagnieAerienneDTO = new CompagnieAerienneDTO();
                                compagnieAerienneDTO.IdCompagnieAerienne = idCompagnieAerienne;
                                compagnieAerienneDTO.Nom = nom;
                                compagnieAerienneDTO.Telephone = telephone;
                                compagnieAerienneDTO.Adresse = adresse;
                                compagnieAerienneDTO.Ville = ville;

                                ApplicationFunctions.CompagnieAerienneFacade.Update(compagnieAerienneDTO);

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
            //ApplicationFunctions.CompagnieAerienneFacade.Update(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Edit/5
        [HttpPost]
        public ActionResult Edit(CompagnieAerienneDTO compagnieAerienneDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.CompagnieAerienneFacade.Update(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CompagnieAerienne()
        {
            return View();
        }
        // GET: CompagnieAerienne/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CompagnieAerienneDTO compagnieAerienneDTO = ApplicationFunctions.CompagnieAerienneFacade.Read(id);
                if (Session["user"] != null && compagnieAerienneDTO != null)
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
                            ApplicationFunctions.CompagnieAerienneFacade.Delete(compagnieAerienneDTO);

                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.CompagnieAerienneFacade.Delete(compagnieAerienneDTO);
            return View();
        }

        // POST: CompagnieAerienne/Delete/5
        [HttpPost]
        public ActionResult Delete(CompagnieAerienneDTO compagnieAerienneDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.CompagnieAerienneFacade.Delete(compagnieAerienneDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}