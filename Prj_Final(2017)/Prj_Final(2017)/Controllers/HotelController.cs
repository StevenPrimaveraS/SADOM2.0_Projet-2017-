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
    public class HotelController : Controller
    {

        //Juste Index

        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                HotelDTO hotelDTO = ApplicationFunctions.HotelFacade.Read(id);
                if (Session["user"] != null && hotelDTO != null)
                {
                    return View();
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // GET: Hotel/Create
        public ActionResult Create(string nom, string telephone, string adresse, string ville, string categorie, string description)
        {
            try
            {
                if (nom != null && telephone != null && adresse != null && ville != null && categorie != null && description != null)
                {
                    HotelDTO hotelDTO = new HotelDTO();
                    hotelDTO.Nom = nom;
                    hotelDTO.Telephone = telephone;
                    hotelDTO.Adresse = adresse;
                    hotelDTO.Ville = ville;
                    hotelDTO.Categorie = categorie;
                    hotelDTO.Description = description;
                    ApplicationFunctions.HotelFacade.Add(hotelDTO);
                }

            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(string nom, string telephone, string adresse, string ville, string categorie, string description)
        {
            try
            {
                HotelDTO hotelDTO = new HotelDTO();
                hotelDTO.Nom = nom;
                hotelDTO.Telephone = telephone;
                hotelDTO.Adresse = adresse;
                hotelDTO.Ville = ville;
                hotelDTO.Categorie = categorie;
                hotelDTO.Description = description;
                ApplicationFunctions.HotelFacade.Update(hotelDTO);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: Hotel/Edit/5
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

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                    HotelDTO hotelDTO = ApplicationFunctions.HotelFacade.Read(id);
                    ApplicationFunctions.HotelFacade.Delete(hotelDTO);
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: Hotel/Delete/5
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
