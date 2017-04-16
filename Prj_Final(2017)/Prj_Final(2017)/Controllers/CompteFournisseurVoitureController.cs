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
    public class CompteFournisseurVoitureController : Controller
    {
        // GET: CompteFournisseurVoiture
        public ActionResult Index()
        {
            return View();
        }
     /*   public ActionResult Create(int idFournisseur, string courriel, string password, int idAgenceVoiture)
        {
            try
            {
                if (Session["user"] != null)
                {
                    CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = new CompteFournisseurVoitureDTO();
                    compteFournisseurVoitureDTO.IdFournisseur = idFournisseur;
                    compteFournisseurVoitureDTO.Courriel = courriel;
                    compteFournisseurVoitureDTO.Password = password;
                    compteFournisseurVoitureDTO.IdAgenceVoiture = idAgenceVoiture;
                    ApplicationFunctions.CompteFournisseurVoitureFacade.Add(compteFournisseurVoitureDTO);
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
        public ActionResult Create(CompteFournisseurVoitureRegisterViewModel model) {
            try {
                if (ModelState.IsValid) {
                    AgenceVoitureDTO agenceVoitureDTO = new AgenceVoitureDTO();
                    agenceVoitureDTO.Nom = model.Nom;
                    agenceVoitureDTO.Telephone = model.Telephone;
                    agenceVoitureDTO.Adresse = model.Adresse;
                    agenceVoitureDTO.Ville = model.Ville;
                    ApplicationFunctions.AgenceVoitureFacade.Add(agenceVoitureDTO);

                    //TODO
                    agenceVoitureDTO = ApplicationFunctions.AgenceVoitureFacade.FindByBasicInfo(agenceVoitureDTO);

                    CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = new CompteFournisseurVoitureDTO();
                    compteFournisseurVoitureDTO.Courriel = model.Courriel;
                    compteFournisseurVoitureDTO.Password = model.Password;
                    compteFournisseurVoitureDTO.IdAgenceVoiture = agenceVoitureDTO.IdAgenceVoiture;
                    ApplicationFunctions.CompteFournisseurVoitureFacade.Add(compteFournisseurVoitureDTO);

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
                    CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = ApplicationFunctions.CompteFournisseurVoitureFacade.Read(id);
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Update(int idFournisseur, string courriel, string password, int idAgenceVoiture)
        {
            try
            {
                if (Session["user"] != null)
                {
                    CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = new CompteFournisseurVoitureDTO();
                    compteFournisseurVoitureDTO.IdFournisseur = idFournisseur;
                    compteFournisseurVoitureDTO.Courriel = courriel;
                    compteFournisseurVoitureDTO.Password = password;
                    compteFournisseurVoitureDTO.IdAgenceVoiture = idAgenceVoiture;
                    ApplicationFunctions.CompteFournisseurVoitureFacade.Add(compteFournisseurVoitureDTO);
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (Session["user"] != null)
            {
                CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = ApplicationFunctions.CompteFournisseurVoitureFacade.Read(id);


                ApplicationFunctions.CompteFournisseurVoitureFacade.Delete(compteFournisseurVoitureDTO);
            }
            return View();
        }
    }
}