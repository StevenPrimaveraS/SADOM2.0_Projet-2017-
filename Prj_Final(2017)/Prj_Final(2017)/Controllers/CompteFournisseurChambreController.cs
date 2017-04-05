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
        public ActionResult Create(int idFournisseur, string courriel, string password, int idhotel)
        {
            try
            {
                CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                compteFournisseurChambreDTO.IdFournisseur = idFournisseur;
                compteFournisseurChambreDTO.Courriel = courriel;
                compteFournisseurChambreDTO.Password = password;
                compteFournisseurChambreDTO.IdHotel = idhotel;
                ApplicationFunctions.CompteFournisseurChambreFacade.Add(compteFournisseurChambreDTO);
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Read(int id)
        {
            try
            {
                CompteFournisseurChambreDTO compteFournisseurChambreDTO = ApplicationFunctions.CompteFournisseurChambreFacade.Read(id);
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return View();
        }
        public ActionResult Update(int idFournisseur, string courriel, string password, int idhotel)
        {
            CompteFournisseurChambreDTO compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
            compteFournisseurChambreDTO.IdFournisseur = idFournisseur;
            compteFournisseurChambreDTO.Courriel = courriel;
            compteFournisseurChambreDTO.Password = password;
            compteFournisseurChambreDTO.IdHotel = idhotel;
            ApplicationFunctions.CompteFournisseurChambreFacade.Update(compteFournisseurChambreDTO);
            return View();
        }
        public ActionResult Delete(int id)
        {
            CompteFournisseurChambreDTO compteFournisseurChambreDTO = ApplicationFunctions.CompteFournisseurChambreFacade.Read(id);

            ApplicationFunctions.CompteFournisseurChambreFacade.Delete(compteFournisseurChambreDTO);
            return View();
        }
    }
}