using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class CompteParticulierController : Controller
    {

        //Juste Create

        // GET: CompteParticulier
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompteParticulier/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CompteParticulierDTO compteParticulierDTO = ApplicationFunctions.CompteParticulierFacade.Read(id);
                if (compteParticulierDTO != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        if (user.IdParticulier == compteParticulierDTO.IdParticulier)
                        {
                            return View();
                        }
                    }
                }
            }catch (VoyageAhuntsicException e){
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // GET: CompteParticulier/Create
        public ActionResult Create() {
            if (Session["user"] == null) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: CompteParticulier/Create
        [HttpPost]
        public ActionResult Create(RegisterViewModel model)
        {
            try {
                if (ModelState.IsValid) {
                    CompteParticulierDTO compteParticulierDTO = new CompteParticulierDTO();
                    compteParticulierDTO.Password = model.Password;
                    compteParticulierDTO.Prenom = model.Name;
                    compteParticulierDTO.Nom = model.LastName;
                    compteParticulierDTO.Courriel = model.Email;
                    ApplicationFunctions.CompteParticulierFacade.Add(compteParticulierDTO);
                    return Redirect("/Account/Login");
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View(model);
        }

        // GET: CompteParticulier/Edit/5
        public ActionResult Edit(string password, string prenom, string nom, string courriel)
        {
            try
            { 
                CompteParticulierDTO compteParticulierDTO = (CompteParticulierDTO)Session["user"];
                compteParticulierDTO.Password = password;
                compteParticulierDTO.Prenom = prenom;
                compteParticulierDTO.Nom = nom;
                compteParticulierDTO.Courriel = courriel;
                ApplicationFunctions.CompteParticulierFacade.Update(compteParticulierDTO);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: CompteParticulier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteParticulier/Delete/5
        public ActionResult Delete()
        {
            try
            {
                CompteParticulierDTO compteParticulierDTO = (CompteParticulierDTO)Session["user"];
                ApplicationFunctions.CompteParticulierFacade.Delete(compteParticulierDTO);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: CompteParticulier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
