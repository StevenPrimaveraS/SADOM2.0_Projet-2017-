using Prj_Final_2017_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class PaiementController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null) {
                if(Session["user"].GetType() == typeof(CompteParticulierDTO)) {
                    base.OnActionExecuting(filterContext);
                }
                else {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                }
            }
            else {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }

        // GET: Paiement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Paiement()
        {
            return View();
        }
        public ActionResult PourTotal(int total)
        {
            ViewBag.TotalChambre = total.ToString();
            return View();
        }
    }
}