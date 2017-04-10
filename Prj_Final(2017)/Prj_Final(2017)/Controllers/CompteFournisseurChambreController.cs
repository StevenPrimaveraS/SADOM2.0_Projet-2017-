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
        public ActionResult Create(FormCollection collections)
        {
            try
            {
                int idFournisseur = Int32.Parse(collections["idFournisseur"]);
                string courriel = collections["courriel"];
                string password = collections["password"];
                int idhotel = Int32.Parse(collections["idhotel"]);

                int idhotel1 = Int32.Parse(collections["idhotel1"]);
                string nom = collections["nom"];
                string telephone = collections["telephone"];
                string adresse = collections["adresse"];
                string ville = collections["ville"];
                string categorie = collections["categorie"];
                string description = collections["description"];
                HotelDTO hotelDTO = new HotelDTO();
                hotelDTO.IdHotel = idhotel1;
                hotelDTO.Nom = nom;
                hotelDTO.Telephone = telephone;
                hotelDTO.Adresse = adresse;
                hotelDTO.Ville = ville;
                hotelDTO.Categorie = categorie;
                hotelDTO.Description = description;
                ApplicationFunctions.HotelFacade.Add(hotelDTO);
                CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                compteFournisseurChambreDTO.IdFournisseur = idFournisseur;
                compteFournisseurChambreDTO.Courriel = courriel;
                compteFournisseurChambreDTO.Password = password;
                compteFournisseurChambreDTO.IdHotel = idhotel;
                ApplicationFunctions.CompteFournisseurChambreFacade.Add(compteFournisseurChambreDTO);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
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