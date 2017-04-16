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
    public class CompteFournisseurChambreController : Controller
    {
        // GET: CompteFournisseurChambre
        public ActionResult Index()
        {
            return View();
        }
    /*    public ActionResult Create(int idFournisseur, string courriel, string password, int idhotel)
        {
            try
            {
                if (Session["user"] != null)
                {
                    CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                    compteFournisseurChambreDTO.IdFournisseur = idFournisseur;
                    compteFournisseurChambreDTO.Courriel = courriel;
                    compteFournisseurChambreDTO.Password = password;
                    compteFournisseurChambreDTO.IdHotel = idhotel;
                    ApplicationFunctions.CompteFournisseurChambreFacade.Add(compteFournisseurChambreDTO);
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }  */
        public ActionResult Create()
        {
      
            return View();
        }
        [HttpPost]
        public ActionResult Create(CompteFournisseurChambreRegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid) {
                    HotelDTO hotelDTO = new HotelDTO();
                    hotelDTO.Nom = model.Nom;
                    hotelDTO.Telephone = model.Telephone;
                    hotelDTO.Adresse = model.Adresse;
                    hotelDTO.Ville = model.Ville;
                    hotelDTO.Categorie = model.Categorie;
                    hotelDTO.Description = model.Description;
                    ApplicationFunctions.HotelFacade.Add(hotelDTO);
                    hotelDTO = ApplicationFunctions.HotelFacade.FindByBasicInfo(hotelDTO);

                    CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                    compteFournisseurChambreDTO.Courriel = model.Courriel;
                    compteFournisseurChambreDTO.Password = model.Password;
                    compteFournisseurChambreDTO.IdHotel = hotelDTO.IdHotel;
                    ApplicationFunctions.CompteFournisseurChambreFacade.Add(compteFournisseurChambreDTO);

                    return Redirect("/Account/Login");
                }
            }
            catch (VoyageAhuntsicException e)
            {
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
                    CompteFournisseurChambreDTO compteFournisseurChambreDTO = ApplicationFunctions.CompteFournisseurChambreFacade.Read(id);
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Update(int idFournisseur, string courriel, string password, int idhotel)
        {
            if (Session["user"] != null)
            {
                CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                compteFournisseurChambreDTO.IdFournisseur = idFournisseur;
                compteFournisseurChambreDTO.Courriel = courriel;
                compteFournisseurChambreDTO.Password = password;
                compteFournisseurChambreDTO.IdHotel = idhotel;
                ApplicationFunctions.CompteFournisseurChambreFacade.Update(compteFournisseurChambreDTO);

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