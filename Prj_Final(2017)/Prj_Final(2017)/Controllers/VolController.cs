﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Final_2017_.Controllers
{
    public class VolController : Controller
    {
        // GET: Vol
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vol() {
            return View();
        }
    }
}