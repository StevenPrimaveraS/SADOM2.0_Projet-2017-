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
    public class CompteFournisseurSiegeController : Controller
    {
        // GET: CompteFournisseurSiege
        public ActionResult Index()
        {
            return View();
        }
      /*  public ActionResult Create(int idFournisseur, string courriel, string password, int idCompagnieAerienne)
        {
            try
            {
                if (Session["user"] != null)
                {
                    CompteFournisseurSiegeDTO compteFournisseurSiegeDTO = new CompteFournisseurSiegeDTO();
                    compteFournisseurSiegeDTO.IdFournisseur = idFournisseur;
                    compteFournisseurSiegeDTO.Courriel = courriel;
                    compteFournisseurSiegeDTO.Password = password;
                    compteFournisseurSiegeDTO.IdCompagnieAerienne = idCompagnieAerienne;
                    ApplicationFunctions.CompteFournisseurSiegeFacade.Add(compteFournisseurSiegeDTO);
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            
            return View();
        }*/
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(CompteFournisseurSiegeRegisterViewModel model) {
            try {
                if (ModelState.IsValid) {
                    CompagnieAerienneDTO compagnieAerienneDTO = new CompagnieAerienneDTO();
                    compagnieAerienneDTO.Nom = model.Nom;
                    compagnieAerienneDTO.Telephone = model.Telephone;
                    compagnieAerienneDTO.Adresse = model.Adresse;
                    compagnieAerienneDTO.Ville = model.Ville;
                    ApplicationFunctions.CompagnieAerienneFacade.Add(compagnieAerienneDTO);

                    //TODO
                    compagnieAerienneDTO = ApplicationFunctions.CompagnieAerienneFacade.FindByBasicInfo(compagnieAerienneDTO);

                    CompteFournisseurSiegeDTO compteFournisseurSiegeDTO = new CompteFournisseurSiegeDTO();
                    compteFournisseurSiegeDTO.Courriel = model.Courriel;
                    compteFournisseurSiegeDTO.Password = model.Password;
                    compteFournisseurSiegeDTO.IdCompagnieAerienne = compagnieAerienneDTO.IdCompagnieAerienne;
                    ApplicationFunctions.CompteFournisseurSiegeFacade.Add(compteFournisseurSiegeDTO);

                    return Redirect("/Home/Index");
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View(model);
        }
        public ActionResult Read(int id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    CompteFournisseurSiegeDTO compteFournisseurSiegeDTO = ApplicationFunctions.CompteFournisseurSiegeFacade.Read(id);
                }
             }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Update(int idFournisseur, string courriel, string password, int idCompagnieAerienne)
        {
            if (Session["user"] != null)
            {
                CompteFournisseurSiegeDTO compteFournisseurSiegeDTO = new CompteFournisseurSiegeDTO();
                compteFournisseurSiegeDTO.IdFournisseur = idFournisseur;
                compteFournisseurSiegeDTO.Courriel = courriel;
                compteFournisseurSiegeDTO.Password = password;
                compteFournisseurSiegeDTO.IdCompagnieAerienne = idCompagnieAerienne;
                ApplicationFunctions.CompteFournisseurSiegeFacade.Update(compteFournisseurSiegeDTO);
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (Session["user"] != null)
            {
                CompteFournisseurChambreDTO compteFournisseurChambreDTO = ApplicationFunctions.CompteFournisseurChambreFacade.Read(id);

                ApplicationFunctions.CompteFournisseurChambreFacade.Delete(compteFournisseurChambreDTO);
            }
            return View();
        }
    }
}