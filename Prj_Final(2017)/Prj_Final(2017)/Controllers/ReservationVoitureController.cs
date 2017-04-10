using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers {
    public class ReservationVoitureController : Controller {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Account/Login");
        }

        // GET: ReservationVoiture
        public ActionResult Index() {
            return View();
        }

        // GET: ReservationVoiture/Details/5
        public ActionResult Details(int id) {
            try {
                //Vérification des permissions
                ReservationVoitureDTO reservationVoitureDTO = ApplicationFunctions.ReservationVoitureFacade.Read(id);
                if (reservationVoitureDTO != null && Session["user"] != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationVoitureDTO.IdParticulier || isAdmin) {
                            ViewBag["reservationVoiture"] = reservationVoitureDTO;
                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            //Redirection sinon
            return RedirectToAction("Index");
        }

        // GET: ReservationVoiture/Delete/5
        public ActionResult Delete(int id) {
            try {
                ReservationVoitureDTO reservationVoitureDTO = ApplicationFunctions.ReservationVoitureFacade.Read(id);
                if (Session["user"] != null && reservationVoitureDTO != null) {
                    if (Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                        CompteParticulierDTO user = (CompteParticulierDTO)Session["user"];
                        bool isAdmin = false;
                        if (Session["admin"] != null) {
                            isAdmin = (bool)Session["admin"];
                        }
                        if (user.IdParticulier == reservationVoitureDTO.IdParticulier || isAdmin) {
                            ApplicationFunctions.ReservationVoitureFacade.Delete(reservationVoitureDTO);

                            return View();
                        }
                    }
                }
            }
            catch (VoyageAhuntsicException e) {
                System.Diagnostics.Debug.WriteLine(VoyageAhuntsicException.CharteErreur[e.NumeroException]);
            }
            return RedirectToAction("Index");
        }

        // POST: ReservationVoiture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
