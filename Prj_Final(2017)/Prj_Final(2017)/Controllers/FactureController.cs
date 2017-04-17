using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class FactureController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (Session["user"] != null) {
                if(Session["user"].GetType() == typeof(CompteParticulierController)) {
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

        // GET: Facture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Facture()
        {
            return View();
        }
    }
}