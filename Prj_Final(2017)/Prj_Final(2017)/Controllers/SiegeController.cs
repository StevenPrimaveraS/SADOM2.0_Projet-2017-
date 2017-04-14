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
    public class SiegeController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: Siege
        public ActionResult Index()
        {
            return View();
        }

        //TODO
        public ActionResult Reserver(int id) {
            string txt = id.ToString();
            ViewBag.IdSiege = txt;
            return View();
        }

        [HttpPost]
        public ActionResult Reserver(int id, FormCollection collection) {
            try {
                string sDateDebut = collection["dateDebut"];
                string sDateFin = collection["dateFin"];
                List<SiegeDTO> panierSiege = (List<SiegeDTO>) Session["panierSiege"];
                List<string> datesSiege = (List<string>) Session["datesSiege"];
                if (panierSiege == null || datesSiege == null) {
                    panierSiege = new List<SiegeDTO>();
                    datesSiege = new List<string>();
                }
                datesSiege.Add(VADateHandler.ToReservationDates(sDateDebut, sDateFin));
                panierSiege.Add(ApplicationFunctions.SiegeFacade.Read(id));
                Session["panierSiege"] = panierSiege;
                Session["datesSiege"] = datesSiege;
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
                return View();
            }

            return Redirect("/Home/Index");
        }
        //END TODO

        // GET: Siege/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //Vérification des permissions
                SiegeDTO siegeDTO = ApplicationFunctions.SiegeFacade.Read(id);
                if(siegeDTO != null)
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
                            ViewBag["Siege"] = siegeDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //ApplicationFunctions.SiegeFacade.Read(siegeDTO.IdSiege);
            return View();
        }

        // GET: Siege/Create
        public ActionResult Create(int idSiege, String type, int numero, int idVol)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO))
                    {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        SiegeDTO siegeDTO= new SiegeDTO();
                        siegeDTO.IdSiege = idSiege;
                        siegeDTO.Type = type;
                        siegeDTO.Numero = numero;
                        siegeDTO.IdVol = idVol;
                        ApplicationFunctions.SiegeFacade.Add(siegeDTO);
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
            ///ApplicationFunctions.SiegeFacade.Add(siegeDTO);
            return View();
        }

        // POST: Siege/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,SiegeDTO siegeDTO)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationFunctions.SiegeFacade.Add(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Siege/Edit/5
        public ActionResult Edit(int idSiege, String type, int numero, int idVol)
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
                                SiegeDTO siegeDTO = new SiegeDTO();
                                siegeDTO.IdSiege = idSiege;
                                siegeDTO.Type = type;
                                siegeDTO.Numero = numero;
                                siegeDTO.IdVol = idVol;

                                ApplicationFunctions.SiegeFacade.Update(siegeDTO);

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

            //ApplicationFunctions.SiegeFacade.Update(siegeDTO);
            return View();
        }

        // POST: Siege/Edit/5
        [HttpPost]
        public ActionResult Edit(SiegeDTO siegeDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ApplicationFunctions.SiegeFacade.Update(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Siege()
        {
            return View();
        }
        // GET: Siege/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SiegeDTO siegeDTO = ApplicationFunctions.SiegeFacade.Read(id);
                if (Session["user"] != null && siegeDTO != null)
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
                            ApplicationFunctions.SiegeFacade.Delete(siegeDTO);

                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e)
            {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            // ApplicationFunctions.SiegeFacade.Update(siegeDTO);
            return View();
        }

        // POST: Siege/Delete/5
        [HttpPost]
        public ActionResult Delete(SiegeDTO siegeDTO, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ApplicationFunctions.SiegeFacade.Update(siegeDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}